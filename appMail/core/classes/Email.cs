using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace appMail.core.classes
{
    public class Email
    {

        public string Provider {  get; set; }   
        public string Username { get; set; }    
        public string Password { get; set; }    

        public Email (string provider, string username, string password) {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Username = username ?? throw new ArgumentNullException(nameof(username)); 
            Password = password ?? throw new ArgumentNullException(nameof(password));
        } 


        public void sendEmail(List<string> emails, string subject, string body, List<string> attachments)
        {
            var message = PreparateMessage(emails, subject, body, attachments);
            sendEmailBySmtp(message);
        }

        private MailMessage PreparateMessage(List<string> emails, string subject, string body, List<string> attachments)
        {
            var mail = new MailMessage();   
            mail.From = new MailAddress(Username);

       
            foreach (var email in emails) {
                if (validateEmail(email))
                {
                    mail.To.Add(email);

                }

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                foreach(var file in attachments)
                {
                    var data = new Attachment(file, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);

                    mail.Attachments.Add(data);
                }
                return mail;    
            }
            return mail;
        }

        private bool validateEmail(string email)
        {
            Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (expression.IsMatch(email))
                return true;
            return false;   
        }

        private void sendEmailBySmtp(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient("smtp.office365.com");
            smtp.Host = Provider;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Timeout = 50000;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Username, Password);
            smtp.Send(message);
            smtp.Dispose();
        }
    }
}
