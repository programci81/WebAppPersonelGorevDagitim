using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPersonelGorevDagitim.Models
{
    public class IBLibStatic
    {
        public const char Tirnak = (char)39;
        
        public static string ToSqlString(string value)
        {
            // tek tirnalari cift tirnak ile degistirir, basina ve sonuna tirnak ekler
            return Tirnak + value.Replace(Tirnak.ToString(), Tirnak.ToString() + Tirnak.ToString()) + Tirnak;
        }

        public static string ToSqlDate(DateTime value)
        {
            return ToSqlString(value.ToString("yyyy-MM-dd"));
        }

        /*

        public static bool IsUserLogin(HttpContext httpContext)
        {
            return !string.IsNullOrEmpty(httpContext.Session.GetString("UserCode"));
        }

        public static int UserId(HttpContext httpContext)
        {
            return Convert.ToInt32(httpContext.Session.GetInt32("UserId"));
        }

        */
    }
}
