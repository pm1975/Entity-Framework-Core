﻿using System.Collections.Generic;

namespace WebApplication1.Database
{
    public interface ISettingsRepository
    {
        List<Setting> GetAll();
        void UpdateSetting(Setting setting);
        Setting GetSettingByName(string name);
        void SaveChanges();
        void DoSomething();
    }
}
