using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Database
{
    public class SettingsRepository
    {
        private WebApplication1DbContext mDbContext;

        private DbSet<Setting> DbSet => mDbContext.Settings;

        public SettingsRepository(WebApplication1DbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public List<Setting> GetAllSettings()
        {
            var list = new List<Setting>();

            var settings = DbSet;

            foreach (var setting in settings)
            {
                list.Add(setting);
            }

            return list;
        }

        public void UpdateSetting(Setting setting)
        {
            var foundSetting = DbSet.Where(x => x.Id == setting.Id).FirstOrDefault();
            if (foundSetting == null)
            {
                DbSet.Add(setting);
                SaveChanges();
                return;
            }

            foundSetting.Name = setting.Name;
            foundSetting.Value = setting.Value;
            SaveChanges();
        }

        public void SaveChanges()
        {
            mDbContext.SaveChanges();
        }
    }
}
