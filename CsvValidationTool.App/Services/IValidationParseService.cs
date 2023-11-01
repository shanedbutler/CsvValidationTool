using CsvValidationTool.Models;

namespace CsvValidationTool.Services
{
    public interface IValidationParseService
    {
        CsvParsingResults ParseEmailColumnRecords(string filename);
        EmailValidationResults ValidateEmails(List<string> emails);
    }
}