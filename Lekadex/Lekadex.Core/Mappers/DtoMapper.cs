using AutoMapper;
using Lekadex.Database;
using System.Collections.Generic;

namespace Lekadex.Core.Mappers
{
    public class DtoMapper
    {
        private IMapper mMapper;
        public DtoMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Medicine, MedicineDto>()
                    .ForMember(x => x.PriceInTotal, opt => opt.MapFrom(y => y.Price * y.Amount))
                    .ReverseMap();
                config.CreateMap<Prescription, PrescriptionDto>()
                    .ReverseMap();
                config.CreateMap<Doctor, DoctorDto>()
                    .ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Maps
        public MedicineDto Map(Medicine medicine) 
            => mMapper.Map<MedicineDto>(medicine);

        public IEnumerable<MedicineDto> Map(IEnumerable<Medicine> medicines)
            => mMapper.Map<IEnumerable<MedicineDto>>(medicines);

        public Medicine Map(MedicineDto medicine)
            => mMapper.Map<Medicine>(medicine);

        public IEnumerable<Medicine> Map(IEnumerable<MedicineDto> medicines)
            => mMapper.Map<IEnumerable<Medicine>>(medicines);

        #endregion

        #region Prescription Maps
        public PrescriptionDto Map(Prescription prescription)
            => mMapper.Map<PrescriptionDto>(prescription);

        public IEnumerable<PrescriptionDto> Map(IEnumerable<Prescription> prescriptions)
            => mMapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);

        public Prescription Map(PrescriptionDto prescription)
            => mMapper.Map<Prescription>(prescription);

        public IEnumerable<Prescription> Map(IEnumerable<PrescriptionDto> prescriptions)
            => mMapper.Map<IEnumerable<Prescription>>(prescriptions);

        #endregion

        #region Doctor Maps
        public DoctorDto Map(Doctor doctor)
            => mMapper.Map<DoctorDto>(doctor);

        public IEnumerable<DoctorDto> Map(IEnumerable<Doctor> doctors)
            => mMapper.Map<IEnumerable<DoctorDto>>(doctors);

        public Doctor Map(DoctorDto doctor)
            => mMapper.Map<Doctor>(doctor);

        public IEnumerable<Doctor> Map(IEnumerable<DoctorDto> doctors)
            => mMapper.Map<IEnumerable<Doctor>>(doctors);

        #endregion
    }
}
