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
        public string DriveID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public int Name { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "user")]
        public string UserID { get; set; }
        [JsonProperty(PropertyName = "cpu")]
        public int CPU { get; set; }
        [JsonProperty(PropertyName = "boot")]
        public int Boot { get; set; }
        [JsonProperty(PropertyName = "mem")]
        public int Memory { get; set; }

          //"ide:0:0": "515b36ec-a674-46a5-9778-00c2b80fee59",
          //"ide:0:0:read:bytes": "2068082688",
          //"ide:0:0:read:requests": "135140",
          //"ide:0:0:write:bytes": "109416628224",
          //"ide:0:0:write:requests": "9072457",
          //"nic:0:dhcp": "69.25.178.8",
          //"nic:0:dhcp:ip": "69.25.178.8",
          //"nic:0:ip": "69.25.178.8",
          //"nic:0:mac": "6a:cc:d6:a2:8e:e3",
          //"nic:0:model": "e1000",
          //"nic:0:rx:bytes": 20022431991,
          //"nic:0:rx:packets": 81171700,
          //"nic:0:tx:bytes": 13452547287,
          //"nic:0:tx:packets": 79487515,
          //"password": "Ygqk8kkQ",
          //"persistent": "true",
          //"server": "5336e65b-6344-42fd-9521-1accd6a28ee3",
          //"smp": "auto",
          //"smp:cores": 1,
          //"started": 1445824156,
          //"status": "active",
          //"type": "vm",
          //"user": "4b3bfc4f-32f3-4a92-bb5e-83624dd6a310",
          //"vnc": "auto",
          //"vnc:ip": "69.25.178.8"
    }
}
