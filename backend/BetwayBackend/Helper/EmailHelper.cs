using System.Net;
using System.Net.Mail;

namespace BackendSolution.Helpers
{
    public class EmailHelper
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailHelper(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }

        public void SendEmail(string recipient, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpHost, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                client.EnableSsl = true;

                var message = new MailMessage(_smtpUsername, recipient, subject, body);
                client.Send(message);
            }
        }
    }
}
