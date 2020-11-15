using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.evl.watch.Utils
{
    public class PasswordUtils
    {
        private string ClearPassword;
        private string EncryptedPassword;
        public PasswordUtils(string ClearPassword, string EncryptedPassword)
        {
            this.ClearPassword = ClearPassword;
            this.EncryptedPassword = EncryptedPassword;
        }
        public PasswordUtils(string ClearPassword)
        {
            this.ClearPassword = ClearPassword;
        }
        public string HashPassword()
        {
            return BCrypt.Net.BCrypt.HashPassword(ClearPassword);
        }

        public bool VerifyPassword()
        {
            return BCrypt.Net.BCrypt.Verify(ClearPassword, EncryptedPassword);
        }

        public bool isBcrypted()
        {
            if ( EncryptedPassword.Length != 60 )
                return false;
            return true;
        }

    }
 
}