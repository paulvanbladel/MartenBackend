using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace MartenBackend.Application
{
    public static class AppConfig
    {
        private static readonly IEnumerable<IConfigurationSection> ConfigElements;
        private const string EnvVarPrefix = "MARTEN_";
        private const string HostKey = "HOST";
        private const string DbNameKey = "DATABASE";
        private const string DbUserKey = "USER";
        private const string DbPasswordKey = "PASSWORD";

        static AppConfig()
        {
            ConfigElements = new ConfigurationBuilder()
                      .AddEnvironmentVariables(EnvVarPrefix)
                      .Build().GetChildren();
        }

        public static string GetConnectionStringBuildFromEnvironmentVariables()
        {
            var host = GetConfigItem(HostKey);
            var db = GetConfigItem(DbNameKey);
            var user = GetConfigItem(DbUserKey);
            var password = GetConfigItem(DbPasswordKey);
            var connectionString = $"host={host};database={db};password={password};username={user}";
            Console.WriteLine($"connection string: {connectionString} ");
            return connectionString;
        }

        private static string GetConfigItem(string itemKey)
        {
            var itemValue = ConfigElements?.FirstOrDefault(e => e.Key == itemKey)?.Value;

            if (itemValue == null)
            {
                throw new Exception($"there is no environment variable for MARTEN_{itemKey} specified");
            }
            return itemValue;
        }
    }
}
