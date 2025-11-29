namespace Subscriber.Configuration.Models
{
    public class ParameterResponseModel
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public List<Item> Parameters { get; set; }
    }

    public class Item
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
