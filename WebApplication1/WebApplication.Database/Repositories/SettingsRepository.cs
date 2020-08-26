using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Database
{
    public class SettingsRepository : BaseRepository<Setting>, ISettingsRepository
    {
        protected override DbSet<Setting> DbSet => mDbContext.Settings;

        public SettingsRepository(WebApplication1DbContext dbContext) : base(dbContext) { }


        public void UpdateSetting(Setting setting)
        {
            var foundSetting = DbSet.Where(x => x.Name == setting.Name).FirstOrDefault();
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

        public Setting GetSettingByName(string name)
        {
            var foundSetting = DbSet.Where(x => x.Name == name).FirstOrDefault();

            return foundSetting;
        }
    }
}
