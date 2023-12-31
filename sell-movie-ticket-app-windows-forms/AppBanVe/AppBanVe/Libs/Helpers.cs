﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppBanVe.Libs
{
    static class Helpers
    {
        public static   string MaHoaMatKhauMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            // Compute hash form the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            // Get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // Change it into 2 hexadecimal digits
                // For each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
