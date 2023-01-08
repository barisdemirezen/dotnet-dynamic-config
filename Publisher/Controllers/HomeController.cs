using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publisher.Data;
using Publisher.Models;
using StackExchange.Redis;
using System.Diagnostics;

namespace Publisher.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Parameters.ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateData(Parameter parameter)
        {
            var k = _context.Parameters.FirstOrDefault(e => e.Id == parameter.Id);

            if (k != null)
            {
                k.ApplicationName = parameter.ApplicationName;
                k.Value = parameter.Value;
                k.Environment = parameter.Environment;
                k.Key = parameter.Key;

                _context.Update(k);
                _context.SaveChanges();
            }

            var db = ConfigurationStore.GetInstance();

            db.Publish("DynamicConfig", JsonConvert.SerializeObject(k));
            
            return RedirectToAction("Index");
        }

        [Route("{id}")]
        public IActionResult Update(int id)
        {
            var data = _context.Parameters.FirstOrDefault(e => e.Id == id);
            return View("Update", data);
        }

    }

    public class ConfigurationStore
    {
        private ConfigurationStore()
        {
            
        }

        private static IDatabase Db { get; set; }

        public static IDatabase GetInstance()
        {
            if (Db == null)
            {
                var db = ConnectionMultiplexer.Connect("localhost:6379").GetDatabase();
                Db = db;
            }
            
            return Db;
        }   

        class ConfigurationStoreData
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}