using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Subscriber.Configuration.Models;
using Subscriber.Controllers;

namespace Subscriber.Configuration
{
    public class ConfigurationService : IHostedService
    {
        private readonly IMemoryCache _memory;
        private readonly IConfiguration _conf;
        private readonly IWebHostEnvironment _env;
        public ConfigurationService(IMemoryCache memory, IConfiguration conf, IWebHostEnvironment env)
        {
            _memory = memory;
            _conf = conf;
            _env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            string applicationName = _conf.GetValue<string>("ApplicationName");
            string environment = _env.EnvironmentName;

            using (HttpClient client = new())
            {
                {
                    var data = client.GetStringAsync($"https://localhost:7080/api?ApplicationName={applicationName}&Environment={environment}").Result;
                    var parameters = JsonConvert.DeserializeObject<List<ParameterResponseModel>>(data);

                    if (parameters == null || parameters.Count == 0)
                        return Task.CompletedTask;

                    foreach (var parameter in parameters)
                        _memory.Set(parameter.Key, parameter.Value);

                }
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
