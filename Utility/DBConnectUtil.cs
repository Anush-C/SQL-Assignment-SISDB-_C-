using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Utility
{
    internal static class DBConnectUtil
    {
        private static IConfiguration _iconfiguration;
        static DBConnectUtil() 
        {
            GetAppSettingsFile();
        }
        
        private static void GetAppSettingsFile() 
        {
            var builder = new ConfigurationBuilder().SetBasePath
               (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
       
    }
}
