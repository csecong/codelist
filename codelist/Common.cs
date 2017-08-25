using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace codelist
{
    public class Common
    {
        /// <summary>
        /// 获取Get/Post/Cookies/ServerVariables 需要引用System.Web
        /// </summary>
        /// <param name="k"></param>
        /// <param name="var"></param>
        /// <returns></returns>
        public static string gpc(string k, string var = "P")
        {
            string return_str = "";

            switch (var)
            {
                case "G":
                    return_str = HttpContext.Current.Request.QueryString[k] == null ? "" : HttpContext.Current.Request.QueryString[k].ToString();
                    break;
                case "P":
                    return_str = HttpContext.Current.Request.Form[k] == null ? "" : HttpContext.Current.Request.Form[k].ToString();
                    break;
                case "S":
                    return_str = HttpContext.Current.Request.ServerVariables[k] == null ? "" : HttpContext.Current.Request.ServerVariables[k].ToString();
                    break;
                case "C":
                    return_str = HttpContext.Current.Request.Cookies[k] == null ? "" : HttpContext.Current.Request.Cookies[k].ToString();
                    break;
                case "R":
                    return_str = System.Web.HttpContext.Current.Request[k] == null ? "" : System.Web.HttpContext.Current.Request[k].ToString();
                    break;
            }
            return return_str;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Encrypt(string input, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            //using (MD5CryptoServiceProvider md5Hash = new MD5CryptoServiceProvider())
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(encoding.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }
    }
}
