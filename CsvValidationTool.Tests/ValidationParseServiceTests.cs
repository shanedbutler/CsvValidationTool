using CsvValidationTool.Models;
using CsvValidationTool.Services;

namespace CsvValidationTool.Tests
{
    public class ValidationParseServiceTests
    {
        [Fact]
        [Trait("Method", "ParseEmailColumnRecords")]
        public void ParseEmailColumnRecords_FileNotFound()
        {
            ValidationParseService service = new ValidationParseService();
            string filename = "nonexistent.csv";

            CsvParsingResults results = service.ParseEmailColumnRecords(filename);

            Assert.Single(results.Errors);
            Assert.Equal("File not found", results.Errors[0]);

        }

        [Fact]
        [Trait("Method", "ParseEmailColumnRecords")]
        public void ParseEmailColumnRecords_EmailColumnNotFound()
        {
            ValidationParseService service = new ValidationParseService();
            string filename = "testNoEmailColumn.csv";

            CsvParsingResults results = service.ParseEmailColumnRecords(filename);

            Assert.Single(results.Errors);
            Assert.Equal("Email column not found", results.Errors[0]);
        }

        [Fact]
        [Trait("Method", "ParseEmailColumnRecords")]
        public void ParseEmailColumnRecords_NoEmailsFound()
        {
            ValidationParseService service = new ValidationParseService();
            string filename = "testNoEmails.csv";

            CsvParsingResults results = service.ParseEmailColumnRecords(filename);

            Assert.Single(results.Errors);
            Assert.Equal("No emails found", results.Errors[0]);
        }

        [Fact]
        [Trait("Method", "ParseEmailColumnRecords")]
        public void ParseEmailColumnRecords_EmailsFound()
        {
            ValidationParseService service = new ValidationParseService();
            string filename = "test.csv";

            CsvParsingResults results = service.ParseEmailColumnRecords(filename);

            Assert.Empty(results.Errors);
            Assert.Equal(3, results.Emails.Count);
            Assert.Equal("foo.bar@example.com", results.Emails[0]);
            Assert.Equal("wbaz@", results.Emails[1]);
            Assert.Equal("no.good", results.Emails[2]);
        }

        [Fact]
        [Trait("Method", "ValidateEmails")]
        public void ValidateEmails_ValidEmails()
        {
            ValidationParseService service = new ValidationParseService();

            List<string> emails = new List<string>()
            {
                "foo.bar@example.com",
                "baz@example.com"
            };

            EmailValidationResults results = service.ValidateEmails(emails);

            Assert.Equal(2, results.ValidEmails.Count);
            Assert.Equal("foo.bar@example.com", results.ValidEmails[0]);
            Assert.Equal("baz@example.com", results.ValidEmails[1]);
        }

        [Fact]
        [Trait("Method", "ValidateEmails")]
        public void ValidateEmails_InvalidEmails()
        {
            ValidationParseService service = new ValidationParseService();

            List<string> emails = new List<string>()
            {
                "wbaz@",
                "no.good"
            };

            EmailValidationResults results = service.ValidateEmails(emails);

            Assert.Equal(2, results.InvalidEmails.Count);
            Assert.Equal("wbaz@", results.InvalidEmails[0]);
            Assert.Equal("no.good", results.InvalidEmails[1]);
        }

        [Fact]
        [Trait("Method", "ValidateEmails")]
        public void ValidateEmails_MixedEmails()
        {
            ValidationParseService service = new ValidationParseService();

            List<string> emails = new List<string>()
            {
                "foo.bar@example.com",
                "baz@example.com",
                "wbaz@",
                "no.good",
            };

            EmailValidationResults results = service.ValidateEmails(emails);

            Assert.Equal(2, results.ValidEmails.Count);
            Assert.Equal("foo.bar@example.com", results.ValidEmails[0]);
            Assert.Equal("baz@example.com", results.ValidEmails[1]);
            Assert.Equal(2, results.InvalidEmails.Count);
            Assert.Equal("wbaz@", results.InvalidEmails[0]);
            Assert.Equal("no.good", results.InvalidEmails[1]);

        }
    }
}
