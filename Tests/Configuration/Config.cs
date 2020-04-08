using System.Configuration;

namespace Tests.Configuration
{
    public static class Config
    {
        public static ConnectionStringSettings ConnectionStringItem => ConfigurationManager.ConnectionStrings["Northwind"];
        public static string ConfigurationString => ConnectionStringItem.Name;
    }
}
