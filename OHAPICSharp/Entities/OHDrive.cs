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
        public string Name { get; set; }
        public long Size { get; set; }
        [JsonProperty(PropertyName = "claimed")]
        public string Claim { get; set; }
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
        //Leaving these out for now, since they are not returned in testing
        //public List<string> Readers { get; set; }
        //public List<string> Tags { get; set; }
        //public List<string> Avoids { get; set; }
    }
}
