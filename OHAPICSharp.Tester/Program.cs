using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OHAPICSharp;
using System.Threading.Tasks;

namespace OHAPICSharp.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var driveService = new OHDriveService();
            var drive = driveService.Create("oh-api-test", 536870912).Result;
            var delete = driveService.Destroy(drive.DriveID).Result;

            if (delete)
                Console.WriteLine("Drive created and deleted");
            else
                Console.WriteLine("There was a problem");
        }

        public static List<OHDrive> GetAllDrives()
        {
            var driveService = new OHDriveService();

            return driveService.GetAll().Result;
        }

        public static OHDrive CreateDrive()
        {
            var driveService = new OHDriveService();

            return driveService.Create("oh-api-test", 536870912).Result;
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
