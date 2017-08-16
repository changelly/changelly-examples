using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Text;
namespace Project.Controllers
{
    public class ChangellyController
    {

      
        private  Encoding U8 = Encoding.UTF8;
        private string apiKey = "xxxxx";
        private string apiSecret = "xxxxx";
        private  string apiUrl = "https://api.changelly.com";

        private string ToHexString(byte[] array)
        {
            StringBuilder hex = new StringBuilder(array.Length * 2);
            foreach (byte b in array)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public async Task<string>  getCurrencies()
        {
            WebClient Client = new WebClient();
            string message = @"{
		        ""jsonrpc"": ""2.0"",
		        ""id"": 1,
		        ""method"": ""getCurrencies"",
		        ""params"": []
			}";

            HMACSHA512 hmac = new HMACSHA512(U8.GetBytes(apiSecret));
            byte[] hashmessage = hmac.ComputeHash(U8.GetBytes(message));
            string sign = ToHexString(hashmessage);

            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Add("api-key", apiKey);
            Client.Headers.Add("sign", sign);
        
            string result = await Client.UploadStringTaskAsync(apiUrl, message);
            return result;
         
        }

        public async Task<string> getMinAmount(string from, string to)
        {
            WebClient Client = new WebClient();
            string message = @"{
		        ""jsonrpc"": ""2.0"",
		        ""method"": ""getMinAmount"",
		        ""params"": {";
          

           string fromvar=" \"from\": \""+ from +"\", ";
            string tovar =" \"to\": \""+ to +"\"  ";

            message= message+fromvar+tovar+ @"  },""id"": 1
			                 }";


            HMACSHA512 hmac = new HMACSHA512(U8.GetBytes(apiSecret));
            byte[] hashmessage = hmac.ComputeHash(U8.GetBytes(message));
            string sign = ToHexString(hashmessage);
            String USER_AGENT = "Mozilla/5.0";
            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Set("User-Agent", USER_AGENT);
            Client.Headers.Set("Accept", "*/*");
            Client.Headers.Set("charset", "utf-8");
            Client.Headers.Add("api-key", apiKey);
            Client.Headers.Add("sign", sign);
           
            string result = await Client.UploadStringTaskAsync(apiUrl, message);
            return result;
         
        }


        public async Task<string> getExchangeAmount(string from, string to,string amount)
        {
            WebClient Client = new WebClient();
            string message = @"{
		        ""jsonrpc"": ""2.0"",
		        ""method"": ""getExchangeAmount"",
		        ""params"": {  ";

            string fromvar = " \"from\": \"" + from + "\", ";
            string tovar = " \"to\": \"" + to + "\" , ";
            string amountvar = "\"amount\":  \""+ amount +"\"";

            message = message + fromvar + tovar + @"       },
                ""id"": 1
			                 }";

            HMACSHA512 hmac = new HMACSHA512(U8.GetBytes(apiSecret));
            byte[] hashmessage = hmac.ComputeHash(U8.GetBytes(message));
            string sign = ToHexString(hashmessage);
            String USER_AGENT = "Mozilla/5.0";
            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Set("User-Agent", USER_AGENT);
            Client.Headers.Set("Accept", "*/*");
            Client.Headers.Set("charset", "utf-8");
            Client.Headers.Add("api-key", apiKey);
            Client.Headers.Add("sign", sign);
        
            string result = await Client.UploadStringTaskAsync(apiUrl, message);
            return result;
          
        }

        public async Task<string> getExchangeCripto(string CurrencyFrom,string CurrencyTo,string AddressWallet)
        {
            WebClient Client = new WebClient();
           
            string message = @"{
		        ""jsonrpc"": ""2.0"",
		        ""method"": ""generateAddress"",
		        ""params"": {";
            string fromvar = " \"from\": \"" + CurrencyFrom + "\", ";
            string tovar = " \"to\": \"" + CurrencyTo + "\" , ";

             string adressvar= "\"address\": \"" + AddressWallet + "\" , ";
            message = message + fromvar+ tovar+ adressvar;
            message = message+ @"""extraId"": null
                   }, 
                ""id"": 1
			                 }";

            HMACSHA512 hmac = new HMACSHA512(U8.GetBytes(apiSecret));
            byte[] hashmessage = hmac.ComputeHash(U8.GetBytes(message));
            string sign = ToHexString(hashmessage);
            String USER_AGENT = "Mozilla/5.0";
   
            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Set("User-Agent", USER_AGENT);
            Client.Headers.Set("Accept", "*/*");
            Client.Headers.Set("charset", "utf-8");
            Client.Headers.Add("api-key", apiKey);
            Client.Headers.Add("sign", sign);
        
            string result = await Client.UploadStringTaskAsync(apiUrl, message);
            return result;
       
        }

   
        public async Task<string> getTransactions(string Currency, string Address)

        {

            WebClient Client = new WebClient();
           
           string message = @"{
		        ""jsonrpc"": ""2.0"",    
		        ""method"": ""getTransactions"",
		        ""params"": {";

            string varcurrency = " \"currency\": \""+ Currency + "\", ";
            string varaddress = "  \"address\":  \""+ Address +"\",";


            message= message+varcurrency+varaddress + @" ""extraId"": null
               },
                ""id"": 1

            }";


            HMACSHA512 hmac = new HMACSHA512(U8.GetBytes(apiSecret));
            byte[] hashmessage = hmac.ComputeHash(U8.GetBytes(message));
            string sign = ToHexString(hashmessage);
            String USER_AGENT = "Mozilla/5.0";
            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Set("User-Agent", USER_AGENT);
            Client.Headers.Set("Accept", "*/*");
            Client.Headers.Set("charset", "utf-8");
            Client.Headers.Add("api-key", apiKey);
            Client.Headers.Add("sign", sign);
          
            string result = await Client.UploadStringTaskAsync(apiUrl, message);
            return result;
          
        }


        public async Task<string> getEstatus(string TransactionId)
        {

            WebClient Client = new WebClient();
         
         string message = @"{
		        ""jsonrpc"": ""2.0"",
		        ""method"": ""getStatus"",
		        ""params"": {";
            
            string varTransaction="    \"id\" : \""+ TransactionId +"\"";


            message=message+varTransaction + @"    },
               ""id"": 1

            }";


            HMACSHA512 hmac = new HMACSHA512(U8.GetBytes(apiSecret));
            byte[] hashmessage = hmac.ComputeHash(U8.GetBytes(message));
            string sign = ToHexString(hashmessage);
            String USER_AGENT = "Mozilla/5.0";
            Client.Headers.Set("Content-Type", "application/json");
            Client.Headers.Set("User-Agent", USER_AGENT);
            Client.Headers.Set("Accept", "*/*");
            Client.Headers.Set("charset", "utf-8");
            Client.Headers.Add("api-key", apiKey);
            Client.Headers.Add("sign", sign);
           
            string result = await Client.UploadStringTaskAsync(apiUrl, message);
            return result;
          
        }



    }
}
