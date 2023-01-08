namespace Subscriber.Configuration.Models
{
    public class ConfigurationStoreData
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Environment { get; set; }
        public string ApplicationName { get; set; }
    }
}
