// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace SendGridTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Execute().Wait();
            Console.WriteLine("Hello World!");
        }

        private static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("james.morgan@thebulb.africa", "ClownKiller");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("muyiwa.olalekan@thebulb.africa", "Example Recipient");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.IsSuccessStatusCode);
        }
    }
}