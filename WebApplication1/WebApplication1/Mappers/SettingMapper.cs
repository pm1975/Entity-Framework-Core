using AutoMapper;
using WebApplication1.Database;

namespace WebApplication1
{
    public class SettingMapper
    {
        private IMapper mMapper;
        public SettingMapper()
        {
            mMapper = new MapperConfiguration(config => 
            {
                //config.CreateMap<Setting, SettingsDataModel>();
                config.CreateMap<Setting, SettingsDataModel>().ReverseMap();
                //config.CreateMap<Setting, SettingsDataModel>().ForMember(x => x.NameOfSetting, x => x.MapFrom(y => y.Name));
            }).CreateMapper();
        }
        public SettingsDataModel Map(Setting setting)
        {
            return mMapper.Map<SettingsDataModel>(setting);
        }

        public Setting Map(SettingsDataModel settingData)
        {
            return mMapper.Map<Setting>(settingData);
        }
    }
}
