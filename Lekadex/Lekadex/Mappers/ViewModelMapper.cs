using AutoMapper;
using Lekadex.Database;
using System.Collections.Generic;

namespace Lekadex.Core.Mappers
{
    public class ViewModelMapper
    {
        private IMapper mMapper;
        public ViewModelMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<MedicineDto, MedicineViewModel>()
                    .ReverseMap();
                config.CreateMap<PrescriptionDto, PrescriptionViewModel>()
                    .ReverseMap();
                config.CreateMap<DoctorDto, DoctorViewModel>()
                    .ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Maps
        public MedicineViewModel Map(MedicineDto medicine) 
            => mMapper.Map<MedicineViewModel>(medicine);

        public IEnumerable<MedicineViewModel> Map(IEnumerable<MedicineDto> medicines)
            => mMapper.Map<IEnumerable<MedicineViewModel>>(medicines);

        public MedicineDto Map(MedicineViewModel medicine)
            => mMapper.Map<MedicineDto>(medicine);

        public IEnumerable<MedicineDto> Map(IEnumerable<MedicineViewModel> medicines)
            => mMapper.Map<IEnumerable<MedicineDto>>(medicines);

        #endregion

        #region Prescription Maps
        public PrescriptionViewModel Map(PrescriptionDto prescription)
            => mMapper.Map<PrescriptionViewModel>(prescription);

        public IEnumerable<PrescriptionViewModel> Map(IEnumerable<PrescriptionDto> prescriptions)
            => mMapper.Map<IEnumerable<PrescriptionViewModel>>(prescriptions);

        public PrescriptionDto Map(PrescriptionViewModel prescription)
            => mMapper.Map<PrescriptionDto>(prescription);

        public IEnumerable<PrescriptionDto> Map(IEnumerable<PrescriptionViewModel> prescriptions)
            => mMapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);

        #endregion

        #region Doctor Maps
        public DoctorViewModel Map(DoctorDto doctor)
            => mMapper.Map<DoctorViewModel>(doctor);

        public IEnumerable<DoctorViewModel> Map(IEnumerable<DoctorDto> doctors)
            => mMapper.Map<IEnumerable<DoctorViewModel>>(doctors);

        public DoctorDto Map(DoctorViewModel doctor)
            => mMapper.Map<DoctorDto>(doctor);

        public IEnumerable<DoctorDto> Map(IEnumerable<DoctorViewModel> doctors)
            => mMapper.Map<IEnumerable<DoctorDto>>(doctors);

        #endregion
    }
}
