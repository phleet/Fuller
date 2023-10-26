using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Fuller.Requests
{
    public abstract class BaseRequest
    {
        private HttpClient Client;
        private string GenerateIdentifier(int length = 8) {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        protected BaseRequest(String hostname, String token)
        {
            Host = hostname;
            Token = token;
            Client = new HttpClient();
        }

        protected dynamic Execute(string path)
        {
            return Execute(path, new Dictionary<string, string>());
        }

        protected dynamic Execute(string path, Dictionary<string, string> data)
        {
            string identifier = GenerateIdentifier(20);
            
            data["api.token"] = Token;
            data["__conduit__"] = "true";
            
            foreach (KeyValuePair<string, string> row in data)
            {
                Console.Out.WriteLine(row.Key + ": " + row.Value);
            }

            String uri = Host + "/api/" + path;

            FormUrlEncodedContent postData = new FormUrlEncodedContent(data);

            Console.WriteLine(JsonConvert.SerializeObject(postData));
            
            HttpResponseMessage response = Client.PostAsync(uri, postData).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject
                      (result);
        }

        public string Host { get; set; }

        public string Token { get; set; }
    }
}