using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OHAPICSharp
{
    public class OHDrives
    {
        private string userID;
        private string secretKey;

        //Constructors
        public OHDrives()
        {
            this.userID = ConfigurationManager.AppSettings["OHUserId"];
            this.secretKey = ConfigurationManager.AppSettings["SecretKey"];
        }

        public OHDrives(string userID, string secretKey)
        {
            this.userID = userID;
            this.secretKey = secretKey;
        }

        //Return a Drive 
        public async Task<OHDrive> Get(string driveID)
        {
            string json = "";

            using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
            {
                var response = await client.GetAsync("drives/515b36ec-a674-46a5-9778-00c2b80fee59/info/full");
                json = await response.Content.ReadAsStringAsync();
            }

            //To do: add Json property attributes to match oh api response
            return JsonConvert.DeserializeObject<OHDrive>(json);
        }
        
    }
}
