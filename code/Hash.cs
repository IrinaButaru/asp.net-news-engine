using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Hash
/// </summary>
public class Hash
{
    public static string GetHashKey(string i_text)
    {
        //Create a new instance of the UnicodeEncoding class to 
        //convert the string into an array of Unicode bytes.
        UnicodeEncoding UE = new UnicodeEncoding();

        //Convert the string into an array of bytes.
        byte[] MessageBytes = UE.GetBytes(i_text);

        //Create a new instance of the SHA1Managed class to create 
        //the hash value.
        SHA1Managed SHhash = new SHA1Managed();

        //Create the hash value from the array of bytes.
        string value = System.Text.Encoding.UTF8.GetString(SHhash.ComputeHash(MessageBytes));

        return value;
    }
}