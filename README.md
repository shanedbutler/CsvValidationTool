# CsvValidationTool
This is a .NET 6 console applcation to find and validate email addresses within a .csv file. Unit testing is performed with xUnit.

Test .csv files have been included for testing. Unit tests could be decoupled from this dependency by mocking the .csv files within the testing framework.

### To run, from repo's root directory:
1. `cd CsvValidationTool.App/`  
2. `dotnet run`

### To run unit tests, from repo's root directory:
1. `cd CsvValidationTool.Tests/`
2. `dotnet test`
