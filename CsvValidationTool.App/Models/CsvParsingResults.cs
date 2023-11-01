namespace CsvValidationTool.Models
{
    public class CsvParsingResults
    {
        public CsvParsingResults()
        {
            Emails = new List<string>();
            Errors = new List<string>();
        }
        public List<string> Emails { get; set; }
        public List<string> Errors { get; set; }
    }
}
