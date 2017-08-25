using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// 验证国内手机号码
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static bool regex_mobile(string tel)
        {
            //电信手机号正则
            string dianxin = @"^1[3578][01379]\d{8}$";
            Regex dReg = new Regex(dianxin);
            //联通手机号正则
            string liantong = @"^1[34578][01256]\d{8}$";
            Regex tReg = new Regex(liantong);
            //移动手机号正则
            string yidong = @"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$";
            Regex yReg = new Regex(yidong);

            if (dReg.IsMatch(tel) || tReg.IsMatch(tel) || yReg.IsMatch(tel))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 过滤html
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string remove_html(string str)
        {
            string regexstr = @"<[^>]*>";
            return System.Text.RegularExpressions.Regex.Replace(str, regexstr, string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        }
        
        /// <summary>
        /// 测试是否复杂密码
        /// </summary>
        /// <param name="pass_str"></param>
        /// <returns></returns>
        public static bool pass_strong(string pass_str)
        {
            var regex = new Regex(@"
(?=.*[0-9])                     #必须包含数字
(?=.*[a-zA-Z])                  #必须包含小写或大写字母
(?=([\x21-\x7e]+)[^a-zA-Z0-9])  #必须包含特殊符号
.{8,30}                         #至少8个字符，最多30个字符
", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            if (regex.IsMatch(pass_str))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }
    }
}
