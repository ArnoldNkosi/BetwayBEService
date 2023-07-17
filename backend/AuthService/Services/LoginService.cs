using System;
using System.Linq;
using AuthService.Helper;
using AuthService.Models;
using AuthService.Requests;
using Microsoft.Extensions.Logging;

namespace AuthService.Services
{
    public class LoginService
    {
        private readonly AppDbContext _dbContext;
        private readonly EncryptionHelper _encryptionHelper;
        private readonly OTPHelper _otpHelper;
        private readonly ILogger<LoginService> _logger;

        public LoginService(AppDbContext dbContext, EncryptionHelper encryptionHelper, OTPHelper otpHelper, ILogger<LoginService> logger)
        {
            _dbContext = dbContext;
            _encryptionHelper = encryptionHelper;
            _otpHelper = otpHelper;
            _logger = logger;
        }

        public bool LoginAttempt(LoginRequest request)
        {
            var user = _dbContext.UserLogins.FirstOrDefault(u => u.Username == request.username);

            if (user != null)
            {
                string decryptedPassword = _encryptionHelper.DecryptPassword(user.Password);
                if (request.password == decryptedPassword)
                {
                    return true;
                }
            }

            return false;
        }

        public void CreateLogin(LoginRequest request)
        {
            string encryptedPassword = _encryptionHelper.EncryptPassword(request.password);

            var user = new UserLogin
            {
                Username = request.username,
                Password = encryptedPassword,
                // Set other properties as needed
            };

            _dbContext.UserLogins.Add(user);
            _dbContext.SaveChanges();
        }

        public bool PasswordReset(string email)
        {
            var user = _dbContext.UserLogins.FirstOrDefault(u => u.Username == email);

            if (user != null)
            {
                string otp = _otpHelper.GenerateOTP(5);
                _otpHelper.SendOTPEmail(user.Username, otp);

                // Save the OTP in the database
              //  user.ResetOTP = otp;
                //user.ResetOTPExpiration = DateTime.UtcNow.AddMinutes(15);

                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool VerifyOTP(string email, string otp)
        {
            var user = _dbContext.UserLogins.FirstOrDefault(u => u.Username == email);

            if (user != null)// && user.ResetOTP == otp && user.ResetOTPExpiration >= DateTime.UtcNow)
            {
                // OTP is valid and not expired
                return true;
            }

            return false;
        }

        public bool ResetPassword(string email, string otp, string newPassword)
        {
            var user = _dbContext.UserLogins.FirstOrDefault(u => u.Username == email);

            if (user != null)// && user.ResetOTP == otp && user.ResetOTPExpiration >= DateTime.UtcNow)
            {
                // OTP is valid and not expired
                string encryptedPassword = _encryptionHelper.EncryptPassword(newPassword);
                user.Password = encryptedPassword;

                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
