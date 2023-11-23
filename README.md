# TeslaTestDrive
Tesla vehicle test drive rental - microservice application

- This project is the idea to mimic the microservices concept: CustomerAPI sends data to the Azure Service Bus, while ReservationsAPI fetches data from the Azure Service Bus


VehicleAPI project handles Vehicle services such as:
- Listing all Vehicles
- Listing a Vehicle by id
- Creating new Vehicle
- Updating existing Vehicle
- Deleting a Vehicle

CustomerAPI project handles Customer services such as:
- Listing all Customers with selected Vehicles
- Pushing a Customer with selected Vehicle (to the Azure Service Bus)
- Deleting a Customer

ReservationAPI project handles Reservation services such as:
- Fetching a Reservation (from the Azure Service Bus)
- Sending email to the Customer

Screenshots of some important steps:

List of Vehicles
https://github.com/markosajerman/TeslaTestDrive/assets/16135187/125efd13-9ce2-44be-9e60-732b9241ad53

Adding Customer to Azure Service Bus
![adding customer to service bus](https://github.com/markosajerman/TeslaTestDrive/assets/16135187/c9d586f5-57d5-43f7-9695-798c6a70a409)

Customer added to Azure Service Bus
![customer added to service bus](https://github.com/markosajerman/TeslaTestDrive/assets/16135187/1ab1974a-962b-40a3-abb9-63d58353de47)

Customer data in form of JSON on Azure Service Bus
![customer JSON on the service bus](https://github.com/markosajerman/TeslaTestDrive/assets/16135187/e07b5ae3-1ed3-40fc-ab8c-681571d80b2e)

Fetching Reservation data from Azure Service Bus (mail still not sent)
![(get) reservation from service bus, before mail is sent](https://github.com/markosajerman/TeslaTestDrive/assets/16135187/e0277e01-9bf4-49ea-8b54-0a0bb77da989)

Reservation data, mail is sent
![(get) reservation after mail is sent](https://github.com/markosajerman/TeslaTestDrive/assets/16135187/62bfe5ef-ba33-4387-a627-86a6998ce384)

Mail context
![mail validation](https://github.com/markosajerman/TeslaTestDrive/assets/16135187/de1d1f0b-ff7b-47cb-b434-b84e2c9d28a1)





