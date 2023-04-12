using Microsoft.AspNetCore.Identity.UI.Services;

namespace BullkyBook.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to send email here
           return Task.CompletedTask;
        }
    }
}
