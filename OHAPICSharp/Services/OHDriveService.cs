using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OHAPICSharp
{
    public class OHDriveService
    {
        private string userID;
        private string secretKey;
        public const string urlBase = "drives/";

        //Constructors
        public OHDriveService()
        {
            this.userID = ConfigurationManager.AppSettings["OHUserId"];
            this.secretKey = ConfigurationManager.AppSettings["OHSecretKey"];
        }

        public OHDriveService(string userID, string secretKey)
        {
            this.userID = userID;
            this.secretKey = secretKey;
        }

        //Return a List of Drives 
        public async Task<List<OHDrive>> GetAll()
        {
            string json = "";
            List<OHDrive> drives = new List<OHDrive>();

            using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
            {
                var url = urlBase + "list";
                var response = await client.GetAsync(url);
                json = await response.Content.ReadAsStringAsync();
            }

            dynamic driveList = JsonConvert.DeserializeObject(json);
            foreach (var drive in driveList)
            {
                string driveId = drive.uuid;
                var response = await Get(driveId);
                drives.Add(response);
            }

            return drives;
        }

        //Return a Drive 
        public async Task<OHDrive> Get(string driveID)
        {
            string json = "";

            using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
            {
                var url = string.Format("{0}{1}/info/full", urlBase, driveID);
                var response = await client.GetAsync(url);
                json = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<OHDrive>(json);
        }

        //Create a Drive 
        public async Task<OHDrive> Create(OHDrive drive)
        {
            string json = "";
            var values = new Dictionary<string, string>();

            //name and size are required
            if (string.IsNullOrEmpty(drive.Name) || drive.Size == 0)
                throw new Exception("Name and Size are required for drive creation");

            values["name"] = drive.Name;
            values["size"] = drive.Size.ToString();
            if (drive.UserID != null)
                values["user"] = drive.UserID;
            if (drive.Encryption != null)
                values["encryption:cipher"] = drive.Encryption;
            
            var content = new FormUrlEncodedContent(values);

            using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
            {
                var url = urlBase + "create";
                var response = await client.PostAsync(url, content);
                json = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<OHDrive>(json);
        }
    }
}
