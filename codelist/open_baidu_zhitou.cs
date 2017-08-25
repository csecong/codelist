using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codelist
{
    class open_baidu_zhitou
    {
        /// <summary>
        /// 百度直投简历解密接口C# 基于base64_decode的中文解密算法
        /// </summary>
        /// <param name="data_str">待解密字符串res</param>
        /// <param name="key">密钥key</param>
        /// <returns>解密后字符串</returns>
        public static string bd_res_encode(string data_str, string key)
        {
            //MD5
            key = Common.Encrypt(key);

            int l = key.Length;
            int x = 0;
            //base64
            byte[] c = Convert.FromBase64String(data_str);
            int len = c.Length;

            string c_str = "";

            for (int i = 0; i < len; ++i)
            {
                if (x == l)
                {
                    x = 0;
                }
                c_str += key[x];
                ++x;
            }
            string res_str = "";

            for (int i = 0; i < len; ++i)
            {
                int c1 = (int)c[i];
                int c2 = (int)c_str.Substring(i, 1)[0];

                if (c1 < c2)
                {
                    res_str += Convert.ToChar(c1 + 256 - c2);
                }
                else
                {
                    res_str += Convert.ToChar(c1 - c2);
                }
            }

            return res_str;
        }
    }
}
