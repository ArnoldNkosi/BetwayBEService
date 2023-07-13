using System;
using BackendSolution.Data;
using BackendSolution.Helper;
using BackendSolution.Models;
using BackendSolution.ServiceImpl;
using Microsoft.EntityFrameworkCore;

namespace BackendSolution.Service
{
    public class LoginService : LoginServiceInterface
    {
        private readonly UserLoginDbContext dbContext;
        public bool LoginCheck(UserLoginRequest userLoginRequest)
        {

            //fetch from database using username
            string username = userLoginRequest.username;

            UserLogin userLogin = new UserLogin();

            if (userLogin!=null && userLogin.password == userLoginRequest.password)
                return true;
            return false ;
        }

        public async void SaveLoginDetails(UserLoginRequest saveUserRequest)
        {
            var userLogin = new UserLogin()
            {
                Id = Guid.NewGuid(),
                username = saveUserRequest.username,
                password = EncryptionHelper.Encrypt(saveUserRequest.password)
            };
            dbContext.userLogins.Add(userLogin);
            await dbContext.SaveChangesAsync();
        }

        public void ResetPassword(UserLoginRequest passwordRestRequest)
        {
            try
            {
                EmailSender emailSender = new EmailSender();
                OtpTokenGenerator otpToken = new OtpTokenGenerator();
                string validToken = otpToken.GenerateOTP(5);
                emailSender.SendEmail(passwordRestRequest.username, "Password-Reset",validToken);

                var token = new OTPTokenModel()
                {
                    Id = Guid.NewGuid(),
                    token = validToken,
                    createdDateTime = DateTime.Now
                };
                //save Token
            }
            catch (Exception ex) { }

        }
    }
}

