using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace OHAPICSharp
{
    public static class OHUtilities
    {
        public static HttpClient CreateClient(string userID, string secretKey)
        {
            HttpClient client = new HttpClient();

            var auth = Convert.ToBase64String(Encoding.ASCII.GetBytes(userID + ":" + secretKey));
            client.BaseAddress = new Uri(@"https://api-east1.openhosting.com/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", auth);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
