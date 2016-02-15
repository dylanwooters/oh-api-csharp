using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OHAPICSharp;
using System.Threading.Tasks;

namespace OHAPICSharp.ConsoleTester
{
    //Test console app for API 
    class Program
    {
        static void Main(string[] args)
        {
            var serverService = new OHServerService("","s");
            var servers = serverService.GetAll().Result;
            Console.WriteLine(servers[0].DriveID);
        }

        //Drive tests
        public static List<OHDrive> GetAllDrives()
        {
            var driveService = new OHDriveService();
            
            return driveService.GetAll().Result;
        }

        public static OHDrive CreateDrive()
        {
            var driveService = new OHDriveService();
            
            return driveService.Create("oh-api-test", 536870912, null).Result;
        }

        public static OHDrive SetDrive()
        {
            var driveService = new OHDriveService();
            var driveOptions = new OHDriveOptions();
            driveOptions.ClaimType = "exclusive";
            driveOptions.Encryption = "none";
            driveOptions.Tags = new[] { "newtest", "c-sharp-api-v2" };
            var drives = driveService.GetAll().Result;
            var drive = drives.FirstOrDefault(x => x.Name == "oh-api-test");

            return driveService.Set(drive.DriveID, drive.Name, 1073741824, driveOptions).Result;
        }

        public static bool DestroyDrive()
        {
            var driveService = new OHDriveService();
            var drives = driveService.GetAll().Result;
            var driveToDelete = drives.FirstOrDefault(x => x.Name == "oh-api-test");
            
            return driveService.Destroy(driveToDelete.DriveID).Result;
        }
    }
}
