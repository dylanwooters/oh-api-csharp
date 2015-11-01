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
            var driveService = new OHDriveService();
            var drives = driveService.GetAll().Result;
            var drive = drives.FirstOrDefault(x => x.Name == "oh-api-test");

            var driveOptions = new OHDriveOptions();
            //driveOptions.Encryption = "aes-xts-plain";
            driveOptions.Tags = new[] { "another-test-tag", "oh-api" };
            drive = driveService.Set(drive.DriveID, drive.Name, 1073741824, driveOptions).Result;

            var deleteOk = driveService.Destroy(drive.DriveID).Result;

            if (deleteOk)
                Console.WriteLine("Drive created and image addded.");
            else
                Console.WriteLine("There was a problem.");
        }

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
