using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data.Common;


namespace engine_stiri_1.code
{
    public class ValidUser
    {
        public static bool CheckUserExist(string user)
        {
            try
            {
                string res = DbConnection.Instance.ExecuteScalarProcedure("ExistingUsername",
                    new KeyValuePair<string, object>("username", user));
                
                if (res == "1")
                    return true;
                return false;

            }
            catch
            {
                return false;
            }
        }
        public static bool CheckLogin(AppUser user)
        {
            try
            {
                string res = DbConnection.Instance.ExecuteScalarProcedure("CheckIfValidUser",
                    new KeyValuePair<string, object>("username", user.UserName),
                    new KeyValuePair<string, object>("password", user.Password));
                if (res == "1")
                    return true;
                return false;

            }
            catch
            {
                return false;
            }
        }
        public static bool CheckAdmin(string user)
        {
            try
            {
                string res = DbConnection.Instance.ExecuteScalarProcedure("IsAdmin",
                     new KeyValuePair<string, object>("username", user));
                if (res == "1")
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckPublisher(string user)
        {
            try
            {
                string res = DbConnection.Instance.ExecuteScalarProcedure("IsPublisher",
                    new KeyValuePair<string, object>("username", user));
                if (res == "1")
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
       
    }
}