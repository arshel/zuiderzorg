
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace zuiderzorg.Pages {
    public class ContactModel : PageModel {
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger) {
            _logger = logger;
        }

        public void OnGet() {
           
        }

        private const string To = "arshelmelfor@gmail.com";
        private const string From = "arshelmelfor@gmail.com";
        
        private const string GoogleAppPassword = "cuqfkkkadrhkodie";
        
        private const string Subject = "Zuiderzorg Contact Formulier";
  
        [BindProperty]
        public MailRequest MailRequest { get;set;}
        public IActionResult OnPost(){

        string  Body = "<p> Naam: " + Request.Form["Name"] + "<br> Bericht: "+ Request.Form["Body"] + "<br> telefoon-nummer: " + Request.Form["TelNumber"] + "<br> Email: " + Request.Form["Email"] +"</p>";
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(From, GoogleAppPassword),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(From),
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(To);

            smtpClient.Send(mailMessage);
            return Page();
        }

    }
}


public class MailRequest {
        
        public string? From { get; set; }
        public string? Name { get; set; }
         public string? Body { get; set; }
          public string? TelNumber { get; set; }
    }
