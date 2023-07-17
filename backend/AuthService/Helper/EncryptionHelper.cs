using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;

namespace AuthService.Helper
{
    public class EncryptionHelper
    {
        private readonly ILogger<EncryptionHelper> _logger;

        public EncryptionHelper(ILogger<EncryptionHelper> logger)
        {
            _logger = logger;
        }

        public string EncryptPassword(string password)
        {
            string encryptedPassword = string.Empty;

            try
            {
                using (var sha256 = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                    encryptedPassword = Convert.ToBase64String(hashBytes);
                }
            }
            catch (Exception ex)
            {
                // Handle encryption error
                _logger.LogError("Password encryption failed: {Error}", ex.Message);
            }

            return encryptedPassword;
        }

        public string DecryptPassword(string password)
        {
            string decryptedPassword = string.Empty;

            try
            {
                // Decrypt password logic here (if applicable)
            }
            catch (Exception ex)
            {
                // Handle decryption error
                _logger.LogError("Password decryption failed: {Error}", ex.Message);
            }

            return decryptedPassword;
        }
    }
}
