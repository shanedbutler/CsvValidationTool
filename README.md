# CsvValidationTool
This is a .NET console applcation to find and validate email addresses within a .csv file.  

Test .csv files have been included for testing. Unit tests could be decoupled from this dependency by mocking the .csv files within the testing framework.

### To run, from root directory:
1. `dotnet restore`  
2. `cd CsvValidationTool.App/`  
3. `dotnet run`

### To run unit tests, from root directory:
1. `cd CsvValidationTool.Tests/`
2. `dotnet test`
