using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace Pet2Share_API.Utility
{
    public static class ConfigMember
    {
        internal static string baseURL = ConfigurationManager.AppSettings["BaseURL"];
        internal static string ImageURL = ConfigurationManager.AppSettings["ImageURL"];
        internal static string ImageFolder = ConfigurationManager.AppSettings["ImagesFolder"];
    }
}
