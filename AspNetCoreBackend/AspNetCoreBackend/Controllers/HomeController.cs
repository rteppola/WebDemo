using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreBackend.Models;

namespace AspNetCoreBackend.Controllers
{
    public class HomeController : Controller //luokka periytyy Controller luokasta
    {
        public IActionResult Index()
        {

            //string tiedosto = @"C:\Users\Reijo\Desktop\Code_Camp\WebDemo\AspNetCoreBackend\AspNetCoreBackend\wwwroot\Otsikot.txt";
            string tiedosto = @"..\AspNetCoreBackend\wwwroot\Otsikot.txt";
            List<string> otsikot = System.IO.File.ReadAllLines(tiedosto).ToList();


            return View(otsikot);
        }

        public IActionResult About()
        {
            // ViewData määritelty Controller luokassa
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}
