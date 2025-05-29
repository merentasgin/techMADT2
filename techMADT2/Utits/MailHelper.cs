using techMADT2.Core.Entities;
using System.Net;
using System.Net.Mail;
namespace techMADT2.Utits
{
    public class MailHelper
    {
        public static async Task<bool> SendMailAsync(Contact contact)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadi.com", 587);
            smtpClient.Credentials = new NetworkCredential("info@techMADT.com", "mailşifresi");
            smtpClient.EnableSsl = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@techMADT.com");
            message.To.Add("bilgi@siteadi.com");
            message.Subject = "Siteden Mesaj Geldi";
            message.Body = $"İsim:{contact.Name}-Soyİsim:{contact.Surname}- Email:{contact.Email}-Telefon:{contact.Phone}-Mesaj{contact.Message}";
            message.IsBodyHtml = true;
            try
            {
                 await smtpClient.SendMailAsync(message);
                smtpClient.Dispose();
                return true;
            }
            catch (Exception)
            {
              return false;
            }
           
        }
        public static async Task<bool> SendMailAsync(string email,string subject,string mailBody)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadi.com", 587);
            smtpClient.Credentials = new NetworkCredential("info@techMADT.com", "mailşifresi");
            smtpClient.EnableSsl = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@techMADT.com");
            message.To.Add(email);
            message.Subject = subject;
            message.Body = mailBody;
            message.IsBodyHtml = true;
            try
            {
                await smtpClient.SendMailAsync(message);
                smtpClient.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
