using System;
using System.Text;

namespace BackendSolution.Helper
{
	public class OtpTokenGenerator
	{
            public string GenerateOTP(int length)
            {
                const string validChars = "0123456789";
                var random = new Random();

                var otp = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    otp.Append(validChars[random.Next(validChars.Length)]);
                }
                return otp.ToString();
            }
        }
}

