using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Coffee_Shop
{
    public class encryptPassword
    {
        public String sha256_hash(String value) //hashing function written using LINQ
        {
            using (SHA256 hash = SHA256Managed.Create())//use SHA 256 algorithm
            {
                return String.Join("", hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }
        }
    }
}