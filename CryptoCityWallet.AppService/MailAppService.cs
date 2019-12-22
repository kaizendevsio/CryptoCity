using System;
using System.Collections.Generic;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using System.IO;

namespace CryptoCityWallet.AppService
{
   public class MailAppService
    {
        public async Task<Response> SendAsync(UserBO userBO)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("./Resources/Templates/Email/EmailConfirmation.html"))
            {
                body = reader.ReadToEnd();
            }

            var apiKey = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var client = new SendGridClient("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");
            var from = new EmailAddress("no-reply@world-ccity.com", String.Format("{0} {1}", userBO.FirstName, userBO.LastName));
            var subject = "World Crypto City : Email Confirmation";
            var to = new EmailAddress(userBO.Email, String.Format("{0} {1}", userBO.FirstName, userBO.LastName));
            var plainTextContent = "";
            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            Response response = await client.SendEmailAsync(msg);

            return response;
        }
    }
}
