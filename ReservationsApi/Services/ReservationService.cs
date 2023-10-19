using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReservationsApi.Data;
using ReservationsApi.Interfaces;
using ReservationsApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;


namespace ReservationsApi.Services
{
    // Service extends IReservation interface
    public class ReservationService : IReservation
    {
        // With dbContext, data from ApiDbContext can be fetched
        private ApiDbContext dbContext;
        // Reservations service constructor
        public ReservationService()
        {
            dbContext = new ApiDbContext(); 
        }
        public async Task<List<Reservation>> GetReservations()
        {
            // Strings provided for connecting to azure and queue on the service bus
            string connectionString = "Endpoint=sb://vehicletestdrivevs.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=r5oy3CKplzT0X8N3tJsEJnCj4h1WPcjn7+ASbKKJwo4=";
            string queueName = "azureorderqueue";
            await using var client = new ServiceBusClient(connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // Receiving messages from the service bus
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(10);
            if (receivedMessages == null)
            {
                return null;
            }

            // For each message in receivedMessages from service bus, return JSON data in form of C# objects using JsonConvert from Newsoft package
            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string body = receivedMessage.Body.ToString();
                // Converts Json data
                var messageCreated = JsonConvert.DeserializeObject<Reservation>(body);
                await dbContext.Reservations.AddAsync(messageCreated);
                await dbContext.SaveChangesAsync();
                // Removing message from the queue
                await receiver.CompleteMessageAsync(receivedMessage);
            }



            return await dbContext.Reservations.ToListAsync();
        }

        // Passing the reservation by id
        public async Task UpdateMailStatus(int id)
        {
            // Checking whether the record is present in the reservations table for this reservation id
            var reservationResult = await dbContext.Reservations.FindAsync(id);
            // If reservationResult is not null and if mail is not sent
            if (reservationResult != null && reservationResult.IsMailSent == false)
            {
                // Then send email to the customer
                var smtpClient = new SmtpClient("smtp.outlook.com", 25)
                {
                    Port = 587,
                    Credentials = new NetworkCredential("markosajermantesting@outlook.com", "mejlZaTestiranje:)"),
                    EnableSsl = true,
                };
                // Testing purposes email created(markosajermantesting@outlook.com)
                // Parameters: from who, to whom, subject/header, body/content
                smtpClient.Send("markosajermantesting@outlook.com", reservationResult.Email, "Vehicle Test Drive", "Your test drive is reserved");
                // When email is sent, setting IsMailSent propertu to true and saving changes
                reservationResult.IsMailSent = true;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
