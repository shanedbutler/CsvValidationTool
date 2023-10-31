using CsvValidationTool.Models;

namespace CsvValidationTool.Services
{
    public class ValidationParseService : IValidationParseService
    {

        /// <summary>
        /// Validates then parses a csv file for email addresses from the email column if existing
        /// </summary>
        /// <param name="filename">Filename of the csv file in input directory</param>
        /// <returns>A ValidationResults object containing a list of emails and/or errors</returns>
        public CsvParsingResults ParseEmailColumnRecords(string filename)
        {
            CsvParsingResults results = new CsvParsingResults();

            if (!File.Exists(filename))
            {
                results.Errors.Add("File not found");
                return results;
            }

            int emailColumnIndex = -1;

            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;  // Skip empty lines

                    string[] values = line?.Split(',');
                    if (values == null || values.Length == 0) continue;  // Skip lines without commas

                    if (emailColumnIndex == -1)
                    {
                        emailColumnIndex = Array.IndexOf(values, "Email");
                        if (emailColumnIndex == -1)
                        {
                            results.Errors.Add("Email column not found");
                            return results;
                        }
                    }
                    else
                    {
                        results.Emails.Add(values[emailColumnIndex]);
                    }
                }
                reader.Close();

                if (results.Emails == null || results.Emails.Count == 0)
                {
                    results.Errors.Add("No emails found");
                }

                return results;
            }
        }

        /// <summary>
        /// Validates a list of emails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns></returns>
        public EmailValidationResults ValidateEmails(List<string> emails)
        {
            EmailValidationResults results = new EmailValidationResults();

            foreach (string email in emails)
            {
                try
                {
                    System.Net.Mail.MailAddress address = new System.Net.Mail.MailAddress(email);
                    results.ValidEmails.Add(email);
                }
                catch
                {
                    results.InvalidEmails.Add(email);
                }
            }

            return results;
        }

    }
}
