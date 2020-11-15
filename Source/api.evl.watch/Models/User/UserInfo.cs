using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace api.evl.watch.Models.User
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }

        public bool Verify()
        {
            if ( string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password) || string.IsNullOrEmpty(this.Email) )
                return false;

            if ( !Regex.IsMatch(this.Email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z") )
                return false;

            return true;

        }

    }
}