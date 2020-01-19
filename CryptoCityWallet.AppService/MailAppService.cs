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
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CryptoCityWallet.AppService
{
   public class MailAppService
    {
        public async Task<Response> SendAsync(UserBO userBO)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("./Resources/Templates/Email/email-confirmation.html"))
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

        public bool SendSmtp(UserBO userBO, EmailType emailType)
        {
            string body = string.Empty;
            
            var mail = new MailMessage()
            {
                From = new MailAddress("no-reply@world-ccity.com"),                
            };

           
            switch (emailType)
            {
                case EmailType.EmailConfirmation:
                    using (StreamReader reader = new StreamReader("./Resources/Templates/Email/email-confirmation.html"))
                    {
                        mail.Body = reader.ReadToEnd();
                    }
                   
                    mail.Subject = "Confirm Email Address";
                    break;
                case EmailType.AccountRegistration:
                    using (StreamReader reader = new StreamReader("./Resources/Templates/Email/email-registration.html"))
                    {
                        mail.Body = reader.ReadToEnd();
                    }

                    mail.Subject = "Confirm Email Address";
                    break;
                default:
                    break;
            }

            try
            {
                // Credentials
                //var credentials = new NetworkCredential("no-reply@world-ccity.com", "HB2!27##piQ4");
                var credentials = new NetworkCredential("apikey", "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");
                // Mail message

                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(userBO.Email));
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.sendgrid.net",
                    //Host = "mx.world-ccity.com",
                    EnableSsl = false,
                    Credentials = credentials
                };
                client.Send(mail);

                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }

        }
    }
}
