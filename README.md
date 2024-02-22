# Coffee Club Application

The Coffee Club application simulates a coffee club at work, where employees can vote on and agree to buy a particular coffee. The application follows a clean architecture design to promote separation of concerns and maintainability.

## Architecture

The application follows a clean architecture pattern, which consists of the following layers:

- **Presentation Layer**: This layer includes the ASP.NET Core Web API project (`CoffeeClub.Api`), which handles HTTP requests and responses. It contains controllers that interact with the MediatR library to execute application use cases. There is also a Blazor Application(`BlazorVotingApp`) which leverages SignalR to allow teams to vote on a coffee.

- **Application Layer**: This layer (`CoffeeClub.Application`) contains the application use cases and business logic. It uses the MediatR library to implement the CQRS (Command Query Responsibility Segregation) pattern. Use cases are implemented as commands or queries, which are handled by corresponding command or query handlers.

- **Domain Layer**: The domain layer (`CoffeeClub.Domain`) represents the core business domain of the application. It contains domain entities, value objects, and domain services. The domain layer should be independent of any infrastructure or application-specific concerns.

- **Persistence Layer**: The persistence layer (`CoffeeClub.Persistence`) is responsible for data access and storage. It includes the database context and repositories that implement the repository pattern. The layer uses Entity Framework Core as the ORM (Object-Relational Mapper) to interact with the underlying database.

## Functionality

The Coffee Club application provides the following functionality:

- **Voting**: Employees can create voting sessions and invite their colleagues to vote for a preferred coffee. Each voting session has a start and end date. Once the voting period ends, the coffee with the highest number of votes is selected as the winning coffee.

- **Coffee Management**: Employees can create, update, and delete coffee options in the system. Coffee options include details such as name, description, price, purchasing link, size, origin, and roast type.

- **Coffee List**: Employees can retrieve a list of available coffees, either by specifying a list of coffee IDs or by retrieving all coffees.

## Getting Started

To run the Coffee Club application locally, follow these steps:

1. Ensure that you have .NET 8.0 SDK installed on your machine.

2. Clone the repository to your local machine.

3. Update the connection string in the `appsettings.json` file of the `CoffeeClub.Api` project to point to your SQL Server database.

4. Open a terminal or command prompt and navigate to the `CoffeeClub.Api` project folder.

5. Run the following command to restore dependencies:

dotnet restore


6. Run the following command to apply the database migrations:

dotnet ef database update


7. Run the following command to start the API:


dotnet run


8. The API will be accessible at `http://localhost:5000`.

## API Documentation

The Coffee Club API is documented using Swagger/OpenAPI. You can access the API documentation by navigating to `http://localhost:5000/swagger` in your web browser. The documentation provides details about the available endpoints, request and response models, and example usage.

## Future Enhancements

Here are some potential enhancements that could be made to the Coffee Club application:

- **Move more logic into Domain layer**: Current implementation depends a lot of the application layer for logic some of that logic should be moved into the domain layer to avoid a Anemic Domain model.

- **Authentication and Authorization**: Implement authentication and authorization mechanisms to ensure that only authorized users can create voting sessions or perform administrative actions.

- **Email Notifications**: Integrate with an email service to send notifications to employees about voting sessions, coffee updates, and other important events.

