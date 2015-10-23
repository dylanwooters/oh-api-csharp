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

            return DeserializeDrive(json);
        }

        //Create a Drive 
        public async Task<OHDrive> Create(string name, long size, OHDriveOptions driveOptions = null)
        {
            string json = "";
            var driveDict = new Dictionary<string, string>();

            //name and size are required
            if (string.IsNullOrEmpty(name) || size == 0)
                throw new Exception("Name and Size are required for drive creation");

            driveDict["name"] = name;
            driveDict["size"] = size.ToString();
            if (driveOptions != null)
            {
                driveDict = SetDriveOptions(driveDict, driveOptions, false);
            }

            json = JsonConvert.SerializeObject(driveDict);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
            {
                var url = urlBase + "create";
                var response = await client.PostAsync(url, content);
                json = await response.Content.ReadAsStringAsync();
            }

            return DeserializeDrive(json);
        }

        //Set Drive options 
        public async Task<OHDrive> Set(string driveID, string name, long size, OHDriveOptions driveOptions = null)
        {
            string json = "";
            var driveDict = new Dictionary<string, string>();

            //name and size are required
            if (string.IsNullOrEmpty(name) || size == 0)
                throw new Exception("Name and Size are required for drive creation");

            driveDict["name"] = name;
            driveDict["size"] = size.ToString();
            if (driveOptions != null)
            {
                driveDict = SetDriveOptions(driveDict, driveOptions, true);
            }

            json = JsonConvert.SerializeObject(driveDict);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
            {
                var url = string.Format("{0}{1}/set", urlBase, driveID);
                var response = await client.PostAsync(url, content);
                json = await response.Content.ReadAsStringAsync();
            }

            return DeserializeDrive(json);
        }

        //Delete a Drive 
        public async Task<bool> Destroy(string driveID)
        {
            HttpResponseMessage response;

            using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
            {
                var url = string.Format("{0}{1}/destroy", urlBase, driveID);
                response = await client.PostAsync(url, null);
            }

            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }

        // Private routines 
        private Dictionary<string, string> SetDriveOptions(Dictionary<string, string> driveDict, OHDriveOptions driveOptions, bool isSetRequest)
        {
            if (!string.IsNullOrEmpty(driveOptions.ClaimType))
                driveDict["claim:type"] = driveOptions.ClaimType;
            if (driveOptions.Readers != null && driveOptions.Readers.Any())
                driveDict["readers"] = string.Join(" ", driveOptions.Readers);
            if (driveOptions.Tags != null && driveOptions.Tags.Any())
                driveDict["tags"] = string.Join(" ", driveOptions.Tags);
            if (!isSetRequest)
            {
                if (driveOptions.Avoids != null && driveOptions.Avoids.Any())
                    driveDict["avoid"] = string.Join(" ", driveOptions.Avoids);
                if (!string.IsNullOrEmpty(driveOptions.Encryption))
                    driveDict["encryption:cipher"] = driveOptions.Encryption;
            }
            return driveDict;
        }

        private OHDrive DeserializeDrive(string json)
        {
            var tempDrive = JsonConvert.DeserializeObject<dynamic>(json);
            var drive = JsonConvert.DeserializeObject<OHDrive>(json);

            if (tempDrive.readers != null)
                drive.Readers = tempDrive.readers.ToString().Split(' ');
            if (tempDrive.tags != null)
                drive.Tags = tempDrive.tags.ToString().Split(' ');
            if (tempDrive.avoid != null)
                drive.Readers = tempDrive.avoid.ToString().Split(' ');

            return drive;
        }

        //This might have to wait until version 2, since I cannot get the image call to work
        //Image a Drive from another drive
        //public async Task<bool> Image(string sourceDriveID, string targetDriveID, string conversion)
        //{
        //    HttpResponseMessage response;

        //    using (HttpClient client = OHUtilities.CreateClient(userID, secretKey))
        //    {
        //        var url = string.Format("{0}{1}/image/{2}/{3}", urlBase, targetDriveID, sourceDriveID, conversion);
        //        response = await client.PostAsync(url, null);
        //    }

        //    if (response.StatusCode == HttpStatusCode.NoContent)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
