using System.Collections.Generic;

namespace Lekadex.Core
{
    public interface IDoctorManager
    {
        void AddNewDoctor(DoctorDto doctor);
        void AddNewMedicine(MedicineDto medicine, int prescriptionId);
        void AddNewPrescription(PrescriptionDto prescription, int doctorId);
        bool DeleteDoctor(DoctorDto doctor);
        bool DeleteMedicine(MedicineDto medicine);
        bool DeletePrescription(PrescriptionDto prescription);
        IEnumerable<DoctorDto> GetAllDoctors(string filterString);
        IEnumerable<MedicineDto> GetAllMedicineForAPrescription(int prescriptionId, string filterString);
        IEnumerable<PrescriptionDto> GetAllPrescriptionForADoctor(int doctorId, string filterString);

    }
}
