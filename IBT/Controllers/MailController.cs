using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> SendEmail(string name, string body, string email)
        {
            var destination = _configuration["RecepientEmail"];
            var token = _configuration["SendGridApiToken"];

            var client = new SendGridClient(token);
            var from = new EmailAddress("noreply@ibtbiotechnology.com", "IBT Industrial Bio Technology");
            var to = new EmailAddress(destination, "IBT Industrial Bio Technology");

            var bodyPlain = "";
            var bodyHtml = "";

            bodyPlain += $"От: {name}{Environment.NewLine}";
            bodyPlain += $"Email: {email}{Environment.NewLine}";
            bodyPlain += $"Сообщение: {body}{Environment.NewLine}";

            bodyHtml += $"<p>От: {name}{Environment.NewLine}</p>";
            bodyHtml += $"<p>Email: {email}{Environment.NewLine}</p>";
            bodyHtml += $"<p>Сообщение: {body}{Environment.NewLine}</p>";

            var msg = MailHelper.CreateSingleEmail(from, to, "Сообщение с контактной формы", bodyPlain, bodyHtml);
            msg.ReplyTo = new EmailAddress(email);
            var response = await client.SendEmailAsync(msg);

            return RedirectToAction("Contacts", "Home");
        }
    }
}