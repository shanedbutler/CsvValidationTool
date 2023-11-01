namespace CsvValidationTool.Models
{
    public class EmailValidationResults
    {
        public EmailValidationResults()
        {
            ValidEmails = new List<string>();
            InvalidEmails = new List<string>();
        }
        public List<string> ValidEmails { get; set; }
        public List<string> InvalidEmails { get; set; }
    }
}
