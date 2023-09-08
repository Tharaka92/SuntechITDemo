# SuntechIT.Demo - Tharaka Herath
## Running the project
This solution uses .Net 6 and SQL Server as the data store. Used VS2022 for the implementation. The connection string looks like below.
> Data Source=.;Initial Catalog=SuntechIT.Demo.Db;Integrated Security=True;

You may need adjustments to this connection string if you use different access settings for SQL Server

Once the project is cloned, Run it and it will apply all the EF Core migrations and insert some seed data.
If that fails then you may need to execute the *SuntechITDemoDBDump.sql* file located in the *document* folder in the root.

The database diagram *SuntechITDemoDBDiagram.png* can be found in the same *document* folder.

## A bit about the project architecture
SuntechIT.Demo project uses CleanArchitecture concepts, CQRS and Domain Driven Design principles.

It is not mandatory to use CQRS for every request. We can use a simple service to process the request instead of using CQRS. 

But for the demo purposes I have only used CQRS for every endpoint.

Presentation layer is decoupled from the web api project to prevent violating separation of concerns. For example, to avoid referencing the db context directly inside the web api project.

I used below third party libraries to avoid re-inventing the wheel;

- [Ardalis.GuardClauses](https://www.nuget.org/packages/Ardalis.GuardClauses)
- [Ardalis.Result](https://www.nuget.org/packages/Ardalis.Result)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://docs.fluentvalidation.net)

This project architecture is very simple and doesn't include all the *bells and whistles*. This is all I could come up with within the given 2 day time period.

Didn't have enough time to complete the "Tickets" CRUD. Sorry about that. It'd just be same as the "Projects" CRUD. 

Thank you!
