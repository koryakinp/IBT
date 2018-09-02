using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using IBT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IBT.Controllers
{
    public class MailController : Controller
    {
        private readonly IConfiguration _configuration;

        public MailController(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessage message, List<IFormFile> files)
        {
            var destination = _configuration["RecepientEmail"];
            var token = _configuration["SendGridApiToken"];

            var client = new SendGridClient(token);
            var from = new EmailAddress("noreply@ibtbiotechnology.com", Consts.COMPANY_NAME);
            var to = new EmailAddress(destination, Consts.COMPANY_NAME);

            var msg = MailHelper.CreateSingleEmail(
                from, 
                to, 
                Consts.EMAIL_TITLE,
                BuildPlainBody(message), 
                BuildHtmlBody(message));

            msg.ReplyTo = new EmailAddress(message.Email);

            foreach (var file in files)
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    var encoded = Convert.ToBase64String(stream.ToArray());
                    msg.AddAttachment(file.FileName, encoded, file.ContentType);
                }
            }

            await client.SendEmailAsync(msg);

            return RedirectToAction("Contacts", "Home");
        }

        private string BuildPlainBody(EmailMessage message)
        {
            var bodyPlain = "";

            bodyPlain += $"От: {message.Name}{Environment.NewLine}";
            bodyPlain += $"Email: {message.Email}{Environment.NewLine}";
            bodyPlain += $"Сообщение: {message.Body}{Environment.NewLine}";

            return bodyPlain;
        }

        private string BuildHtmlBody(EmailMessage message)
        {
            var bodyHtml = "";
            bodyHtml += $"<p>От: {message.Name}{Environment.NewLine}</p>";
            bodyHtml += $"<p>Email: {message.Email}{Environment.NewLine}</p>";
            bodyHtml += $"<p>Сообщение: {message.Body}{Environment.NewLine}</p>";

            return bodyHtml;
        }
    }
}