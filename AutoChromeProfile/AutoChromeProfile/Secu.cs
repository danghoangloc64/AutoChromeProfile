using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChromeProfile
{
    class Secu
    {
        private static string key = "amejpay-payment-gateway-woocommerce";

        public static string Base64Encode(string plainText)
        {
            plainText += key;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes).Replace(key, "");
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
