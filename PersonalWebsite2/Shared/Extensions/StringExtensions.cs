﻿using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PersonalWebsite2.Shared.Extensions {
    public static class StringExtensions {

        public static string UrlEncode(this string value)
        {
            return HttpUtility.UrlEncode(value);
        }

        public static int RowCount(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 1;
            return value.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Length;
        }

        public static string Encrypt(this string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] hash = HashAlgorithm.Create("SHA256").ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}