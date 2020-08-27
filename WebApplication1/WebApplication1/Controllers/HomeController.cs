﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Schema;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider mServiceProvider;
        private readonly ISettingsRepository mSettingsRepository;
        private readonly UserManager<ApplicationUser> mUserManager;
        private readonly SettingMapper mSettingMapper;
        private readonly SignInManager<ApplicationUser> mSingInManager;

        public HomeController(IServiceProvider serviceProvider,
            ISettingsRepository settingRepository,
            UserManager<ApplicationUser> userManager,
            SettingMapper settingMapper,
            SignInManager<ApplicationUser> signInManager)
        {
            mServiceProvider = serviceProvider;
            mSettingsRepository = settingRepository;
            mUserManager = userManager;
            mSettingMapper = settingMapper;
            mSingInManager = signInManager;

            var user = userManager.FindByNameAsync("login").Result;

            mSingInManager.SignInAsync(user, false, "haslo123");
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

            #region CreatingUser

            //var user = new ApplicationUser
            //{
            //    FirstName = "Piotr",
            //    LastName = "Mierniczak",
            //    UserName = "KursProgramowania1"
            //};

            //var result = mUserManager.CreateAsync(user, "haslo123").Result;
            //if (result.Succeeded)
            //{
            //    return View();
            //}

            //return Ok("Nie udało się stworzyć użytkownika");

            #endregion

            #region 10EntityRepositoryCoToJest
            //var database = mServiceProvider.GetService(typeof(WebApplication1DbContext)) as WebApplication1DbContext;
            //var repository = new SettingsRepository(database);
            //repository.UpdateSetting(new Setting
            //{
            //    Name = "TextColor",
            //    Value = "Black"
            //});

            //var databaseSettings = repository.GetAllSettings();

            //return Ok(databaseSettings);
            #endregion

            #region Update
            //mSettingsRepository.UpdateSetting(new Setting
            //{
            //    Name = "BackgroundColor",
            //    Value = "Yellow"
            //});

            //var databaseSettings = mSettingsRepository.GetAll();
            #endregion

            //var setting = mSettingsRepository.GetSettingByName("BackgroundColor");

            //var dataModelSetting = mSettingMapper.Map(setting);

            //dataModelSetting.Value = "Yellow";

            //var newSetting = mSettingMapper.Map(dataModelSetting);

            //mSettingsRepository.SaveChanges();

            var databaseSettings = mSettingsRepository.GetAll();

            return Ok(databaseSettings);

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
