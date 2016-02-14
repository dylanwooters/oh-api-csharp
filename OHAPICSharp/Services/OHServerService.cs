using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OHAPICSharp
{
    public class OHServerService : OHService
    {
        public const string urlBase = "servers/";

        public OHServerService() : base() { }
        public OHServerService(string UserID, string SecretKey) : base(UserID, SecretKey) { }

        //Return a List of Drives 
        public async Task<List<OHServer>> GetAll()
        {
            string json = "";
            List<OHServer> servers = new List<OHServer>();

            using (HttpClient client = OHUtilities.CreateClient(UserID, SecretKey))
            {
                var url = urlBase + "list";
                var response = await client.GetAsync(url);
                json = await response.Content.ReadAsStringAsync();
            }

            dynamic serverList = JsonConvert.DeserializeObject(json);
            foreach (var server in serverList)
            {
                string serverId = server.uuid;
                var response = await Get(serverId);
                servers.Add(response);
            }

            return servers;
        }

        //Return a Server 
        public async Task<OHServer> Get(string serverID)
        {
            string json = "";

            using (HttpClient client = OHUtilities.CreateClient(UserID, SecretKey))
            {
                var url = string.Format("{0}{1}/info/full", urlBase, serverID);
                var response = await client.GetAsync(url);
                json = await response.Content.ReadAsStringAsync();
            }

            return DeserializeServer(json);
        }

        private OHServer DeserializeServer(string json)
        {
            //var tempServer = JsonConvert.DeserializeObject<dynamic>(json);
            var server = JsonConvert.DeserializeObject<OHServer>(json);

            //if (tempDrive.readers != null)
            //    drive.Readers = tempDrive.readers.ToString().Split(' ');
            //if (tempDrive.tags != null)
            //    drive.Tags = tempDrive.tags.ToString().Split(' ');
            //if (tempDrive.avoid != null)
            //    drive.Readers = tempDrive.avoid.ToString().Split(' ');

            return server;
        }
    }
}
