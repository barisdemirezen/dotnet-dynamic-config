using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;
using Subscriber.Configuration.Models;

namespace Subscriber.Configuration
{
    public class ConfigurationStore
    {
        private readonly IMemoryCache _memory;

        public ConfigurationStore(IMemoryCache memory, IConfiguration c, IWebHostEnvironment env)
        {
            _memory = memory;

            var redisHost = c.GetValue<string>("DynamicConfig:Redis:Host");
            var redisPort = c.GetValue<int>("DynamicConfig:Redis:Port");
            var redisDatabase = c.GetValue<int>("DynamicConfig:Redis:Database");
            var redisPassword = c.GetValue<string>("DynamicConfig:Redis:Password");

            var applicationName = c.GetValue<string>("DynamicConfig:ApplicationName");
            var environmentName = env.EnvironmentName;

            var redis = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { $"{redisHost}:{redisPort}" },
                Password = redisPassword,
                DefaultDatabase = redisDatabase,
            });

            redis.GetSubscriber().Subscribe("DynamicConfig", (channel, message) =>
            {
                if (string.IsNullOrEmpty(message))
                    return;

                var data = JsonConvert.DeserializeObject<ConfigurationStoreData>(message);

                if (environmentName == data.Environment && applicationName == data.ApplicationName)
                    _memory.Set(data.Key, data.Value);
                
            });
        }
        
        public string GetString(string key)
        {
            var data = _memory.Get<string>(key);

            if (string.IsNullOrEmpty(data))
                return string.Empty;

            return data;
        }

        public int GetInt(string key)
        {
            var data = GetString(key);

            if (string.IsNullOrEmpty(data))
                return default;

            if (int.TryParse(data, out int result))
                return result;

            return default;
        }
    }
}
