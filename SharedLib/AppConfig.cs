using Microsoft.Extensions.Configuration;

namespace SharedLib
{
    public class AppConfig
    {
        public static IConfigurationRoot Configuration { get; set; }


        public static IConfigurationSection GetSection(string name)
        {
            return Configuration?.GetSection(name);
        }
       
        public static string GetConnectionString(string key)
        {
            return Configuration?.GetConnectionString(key);
        }
    }
}
