using System.Collections.Generic;

namespace WebApplication1.Database
{
    public interface ISettingsRepository
    {
        List<Setting> GetAll();
        void UpdateSetting(Setting setting);
        void SaveChanges();
    }
}
