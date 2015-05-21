using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHAPICSharp
{
    class OHDrive
    {
        public string DriveID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Claim { get; set; }
        public string Status { get; set; }
        public string Encryption { get; set; }
        public string UserID { get; set; }
        public int WriteBytes { get; set; }
        public int WriteRequests { get; set; }
        public int ReadBytes { get; set; }
        public int ReadRequests { get; set; }
        public List<string> Readers { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Avoids { get; set; }
    }
}
