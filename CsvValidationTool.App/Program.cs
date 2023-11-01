using Microsoft.Extensions.DependencyInjection;
using CsvValidationTool.Services;
using CsvValidationTool.Models;

namespace CsvValidationTool
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            // Set up dependency injection
            var services = new ServiceCollection();
            services.AddTransient<IValidationParseService, ValidationParseService>();
            _serviceProvider = services.BuildServiceProvider();
            IValidationParseService validationParseService = _serviceProvider.GetService<IValidationParseService>();

            string filename = string.Empty;

            while (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("Enter filename: ");
                filename = Console.ReadLine();
            }

            CsvParsingResults parsedEmailResults = validationParseService.ParseEmailColumnRecords(filename);

            if (parsedEmailResults.Errors.Count > 0)
            {
                foreach (string error in parsedEmailResults.Errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                EmailValidationResults emailValidationResults = validationParseService.ValidateEmails(parsedEmailResults.Emails);

                if (emailValidationResults.ValidEmails.Count > 0)
                {
                    Console.WriteLine("Valid emails:");
                    foreach (string validEmail in emailValidationResults.ValidEmails)
                    {
                        Console.WriteLine(validEmail);
                    }
                }
                if (emailValidationResults.InvalidEmails.Count > 0)
                {
                    Console.WriteLine("Invalid emails:");
                    foreach (string invalidEmail in emailValidationResults.InvalidEmails)
                    {
                        Console.WriteLine(invalidEmail);
                    }
                }
            }
        }
    }
}