using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engine_stiri_1.code
{
    public class AppUser
    {
        public AppUser(string lname, string fname, string uname, string pass, string email,string phone, string utype,string status)
        {
            LastName = lname;
            FirstName = fname;
            UserName = uname;
            Password = pass;
            Email = email;
            PhoneNumber = phone;
            UserType = utype;
            Status = status;
          
        }

        public string FirstName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public string Email
        {
            get;
            private set;
        }

        public string PhoneNumber
        {
            get;
            private set;
        }

        public string UserType
        {
            get;
            private set;
        }

        public string UserName
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }
        public string Status
        {
            get;
            private set;
        }
    }
}