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
            var response = CreateDrive();

            Console.Write(response.Name);
        }

        public static OHDrive CreateDrive()
        {
            var driveService = new OHDriveService();
            var drive = new OHDrive();
            drive.Name = "test";
            drive.Size = 536870912;

            return driveService.Create(drive).Result;
        }

        public static List<OHDrive> GetAllDrives()
        {
            var driveService = new OHDriveService();

            return driveService.GetAll().Result;
        }
    }
}
