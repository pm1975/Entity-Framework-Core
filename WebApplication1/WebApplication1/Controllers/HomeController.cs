using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider mServiceProvider;

        public HomeController(IServiceProvider serviceProvider)
        {
            mServiceProvider = serviceProvider;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            #region DbContextPrzykłady
            /*var database = mServiceProvider.GetService(typeof(WebApplication1DbContext)) as WebApplication1DbContext;
            var settingsTable = database.Settings;

            #region Dodajemy nowe ustawienia tła
            //var newSetting = new Setting
            //{
            //    Name = "Background",
            //    Value = "Black"
            //};
            //settingsTable.Add(newSetting);
            #endregion

            #region Usuwamy duplikat czarnego tła
            //var firstBackgroundSetting = settingsTable.Where(x => x.Name == "Background").First();
            //settingsTable.Remove(firstBackgroundSetting);
            #endregion

            #region Zmienmy istniejacy background na red
            var backgroundSetting = settingsTable.First();
            backgroundSetting.Value = "Red";
            #endregion
            database.SaveChanges();*/
            #endregion

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
    }
}
