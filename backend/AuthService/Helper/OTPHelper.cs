using System;
using System.Net;
using System.Net.Mail;

namespace AuthService.Helper
{
    public class OTPHelper
    {
        public string GenerateOTP(int length)
        {
            const string characters = "1234";
            var random = new Random();
            var otp = new char[length];

            for (int i = 0; i < length; i++)
            {
                otp[i] = characters[random.Next(characters.Length)];
            }

            return new string(otp);
        }

        public void SendOTPEmail(string email, string otp)
        {
            string smtpHost = "smtpHost";
            int smtpPort = 587;
            string smtpUsername = "betwayTest";
            string smtpPassword = "betwayPassword";

            string senderEmail = "betway@test.com";
            string senderName = "Betway Auth Team";
            string subject = "OTP for password reset";
            string body = $"Your OTP: {otp}";

            try
            {
                using (var client = new SmtpClient(smtpHost, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    client.EnableSsl = true;

                    var message = new MailMessage();
                    message.From = new MailAddress(senderEmail, senderName);
                    message.To.Add(email);
                    message.Subject = subject;
                    message.Body = body;

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                // Handle email sending error
                Console.WriteLine("Failed to send email due to: " + ex.Message);
            }
        }
    }
}
