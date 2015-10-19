using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OHAPICSharp
{
    public class OHDrive
    {
        [JsonProperty(PropertyName = "drive")]
        public string DriveID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "size")]
        public long Size { get; set; }
        [JsonProperty(PropertyName = "claimed")]
        public string Claim { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "encryption:cipher")]
        public string Encryption { get; set; }
        [JsonProperty(PropertyName = "user")]
        public string UserID { get; set; }
        [JsonProperty(PropertyName = "write:bytes")]
        public long WriteBytes { get; set; }
        [JsonProperty(PropertyName = "write:requests")]
        public long WriteRequests { get; set; }
        [JsonProperty(PropertyName = "read:bytes")]
        public long ReadBytes { get; set; }
        [JsonProperty(PropertyName = "read:requests")]
        public long ReadRequests { get; set; }
        [JsonIgnore]
        public string[] Readers { get; set; }
        [JsonIgnore]
        public string[] Tags { get; set; }
        [JsonIgnore]
        public string[] Avoids { get; set; }
    }

    public class OHDriveOptions
    {
        public string ClaimType { get; set; }
        public string[] Readers { get; set; }
        public string[] Tags { get; set; }
        public string[] Avoids { get; set; }
        public string Encryption { get; set; }
    }
}
