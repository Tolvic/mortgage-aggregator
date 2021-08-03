# Mortgage Aggregator
## Local Setup

Clone this repo

Build the solution

* This can be done either through visual studio or by running the `dotnet build` command from the root directory

Set up a Database
* Ensure that you have SQL Server installed
* Ensure that the connection string server name in MortageAggregator.API > `appsettings.json` matches your local sql server name
* Within in Visual Studio > Package Manager Console run `Update-Database`

Run the solution

* This can be done either through visual studio or using the dotnet run command