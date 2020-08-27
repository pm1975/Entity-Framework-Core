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

        public void DoSomething()
        {
            //LINQ
            //Where
            var foundSetting = DbSet.Where(x => x.Name == "Background").First();
            foundSetting = DbSet.Where(x => x.Id > 3 && x.Id < 6).First();

            //Select
            var listOfValues = DbSet.Where(x => x.Id > 3 && x.Id < 6).Select(x => x.Value);
            var list = listOfValues.ToList();
            //select 2 kolumny, 3 dodana "w locie"
            var foundSetting2 = DbSet.Where(x => x.Id > 3 && x.Id < 6).Select(x => new
            {
                NameX = x.Name,
                ValueX = x.Value,
                Sum = x.Name + x.Value
            });
            var list2 = foundSetting2.ToList();

            //OrderBy
            DbSet.Where(x => x.Id > 3 && x.Id < 6).OrderBy(x => x.Name);

            //Take
            //pobieże 3 obiekty
            DbSet.Where(x => x.Id > 3 && x.Id < 6).Take(3);

            //Skip
            //pomija 2 pierwsze
            DbSet.Where(x => x.Id > 1 && x.Id < 6).Skip(2);

            //zagnieżdzanie operacji
            DbSet.Where(x => x.Id > 1 && x.Id < 6)
                .Skip(2)
                .Select(x => x.Value)
                .OrderBy(x => x)
                .Take(1)
                .ToList();
        }
    }
}
