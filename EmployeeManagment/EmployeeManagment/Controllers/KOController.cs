using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeManagment.Controllers
{
    public class KOController : Controller
    {
        public IActionResult Index()
        {
            var initialState = new[]
            {
                new GiftModel {Title="Tall Hat", Price= 49.95 },
                new GiftModel {Title="Long Cloack", Price = 78.25}
            };
          //  List<string> data = JsonConvert.DeserializeObject<List<string>>(initialState);
            //   var daro = JsonConvert.DeserializeObject<arr<initialState>>();
            string json = @"['Starcraft','Halo','Legend of Zelda']";

            List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);

            // var daro = JsonConvert.DeserializeObject<List<Dictionary<string, Dictionary<string, string>>>>(initialState);
            // var initialData = new JavaScriptSerializer().Serialize();
            return View(initialState);
        }
    }
    public class GiftModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
    }
}