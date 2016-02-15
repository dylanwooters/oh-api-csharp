using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OHAPICSharp
{
    public class OHServer
    {
        [JsonProperty(PropertyName = "server")]
        public string ServerID { get; set; }
        [JsonProperty(PropertyName = "ide:0:0")]
        public string DriveID { get; set; }
        [JsonProperty(PropertyName = "user")]
        public string UserID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "cpu")]
        public int CPU { get; set; }
        [JsonProperty(PropertyName = "mem")]
        public int Memory { get; set; }
        [JsonProperty(PropertyName = "nic:0:ip")]
        public string IP { get; set; }
        [JsonProperty(PropertyName = "nic:0:mac")]
        public string MAC { get; set; }
        [JsonProperty(PropertyName = "ide:0:0:write:bytes")]
        public long WriteBytes { get; set; }
        [JsonProperty(PropertyName = "ide:0:0:write:requests")]
        public long WriteRequests { get; set; }
        [JsonProperty(PropertyName = "ide:0:0:read:bytes")]
        public long ReadBytes { get; set; }
        [JsonProperty(PropertyName = "ide:0:0:read:requests")]
        public long ReadRequests { get; set; }
        [JsonProperty(PropertyName = "nic:0:rx:bytes")]
        public long BytesReceived { get; set; }
        [JsonProperty(PropertyName = "nic:0:rx:packets")]
        public long PacketsReceived { get; set; }
        [JsonProperty(PropertyName = "nic:0:tx:bytes")]
        public long BytesTransferred { get; set; }
        [JsonProperty(PropertyName = "nic:0:tx:packets")]
        public long PacketsTransferred { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "persistent")]
        public string Persistent { get; set; }
        [JsonProperty(PropertyName = "smp:cores")]
        public string Cores { get; set; }
        [JsonProperty(PropertyName = "started")]
        public int StartDateUTC { get; set; }
        [JsonProperty(PropertyName = "vnc:ip")]
        public string VNCIP { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
