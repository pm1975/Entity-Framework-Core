using Lekadex.Core;
using Lekadex.Core.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lekadex.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IDoctorManager mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;

        private int DoctorId { get; set; }
        private int PrescriptionId { get; set; }
        public MedicineController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int doctorId, int prescriptionId, string filterString)
        {
            DoctorId = doctorId;
            PrescriptionId = prescriptionId;

            var prescriptionDtos = mDoctorManager.GetAllPrescriptionForADoctor(doctorId, null)
                                                 .FirstOrDefault(x => x.Id == prescriptionId);
            var medicineDtos = mDoctorManager.GetAllMedicineForAPrescription(prescriptionId, filterString);

            var viewModels = mViewModelMapper.Map(prescriptionDtos);

            if (string.IsNullOrEmpty(filterString))
            {
                return View(TestDatabasePleaseDelete.Doctors.ElementAt(doctorId)
                .Prescriptions.ElementAt(prescriptionId));
            }

            return View(new PrescriptionViewModel
            {
                Name = TestDatabasePleaseDelete.Doctors.ElementAt(doctorId)
                    .Prescriptions.ElementAt(prescriptionId).Name,
                Medicines = TestDatabasePleaseDelete.Doctors.ElementAt(doctorId)
                    .Prescriptions.ElementAt(prescriptionId).Medicines
                    .Where(x => x.Name.Contains(filterString)).ToList()
            });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineVm)
        {
            TestDatabasePleaseDelete.Doctors.ElementAt(DoctorId)
                .Prescriptions.ElementAt(PrescriptionId)
                .Medicines.Add(medicineVm);

            //wrócimy z powrotem do Index
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int indexOfMedicine)
        {
            return View();
        }
    }
}
