using System;
using System;
using System.Net;
using System.Net.Mail;

namespace BackendSolution.Helper
{
    public class EmailSender
    {
        public void SendEmail(string recipientEmail, string subject, string body)
        {
            // Set the email sender and recipient information
            string senderEmail = "your-email@example.com"; // Replace with your email address
            string senderPassword = "your-email-password"; // Replace with your email password

            // Create a new MailMessage object
            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);

            // Create a new SmtpClient object
            SmtpClient smtpClient = new SmtpClient("smtp.example.com", 587); // Replace with your SMTP server and port

            // Set the SMTP credentials
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email: " + ex.Message);
            }
        }
    }

}

