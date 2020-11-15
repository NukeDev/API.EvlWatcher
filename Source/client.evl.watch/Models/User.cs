using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.evl.watch.Models
{
    /// <summary>
    /// This is the User POST Object used for Register a new account
    /// </summary>
    public class User
    {   /// <summary>
        /// Username: It must be a string, max 100 chars
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password: It must be a string, max 60 chars, and IT MUST BE BCRYPTED with $2a$ version (If you use client.evl.watch it will be done automatically)
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Username: It must be a string, max 150 chars, it will be validated by server
        /// </summary>
        public string Email { get; set; }
    }
}
