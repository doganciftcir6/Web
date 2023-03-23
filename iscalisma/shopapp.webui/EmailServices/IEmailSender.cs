using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//üyelik için onay email göndeircez
namespace shopapp.webui.EmailServices
{
    public interface IEmailSender
    {
        //smtp server => gmail,hotmail
        //api => sendgrid

        //metot
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
