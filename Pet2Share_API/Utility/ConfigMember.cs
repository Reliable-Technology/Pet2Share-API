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
        internal static string baseURL = ConfigurationSettings.AppSettings["BaseURL"];
        internal static string ImageURL = ConfigurationSettings.AppSettings["ImageURL"];
        internal static string ImageFolder = ConfigurationSettings.AppSettings["ImagesFolder"];
    }
}
