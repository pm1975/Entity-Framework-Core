using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lekadex.Controllers
{
    public class MedicineController : Controller
    {
        private int IndexOfDoctor { get; set; }
        private int IndexOfPrescription { get; set; }
        public MedicineController()
        {

        }

        public IActionResult Index(int indexOfDoctor, int indexOfPrescription, string filterString)
        {
            IndexOfDoctor = indexOfDoctor;
            IndexOfPrescription = indexOfPrescription;

            if (string.IsNullOrEmpty(filterString))
            {
                return View(TestDatabasePleaseDelete.Doctors.ElementAt(indexOfDoctor)
                .Prescriptions.ElementAt(indexOfPrescription));
            }

            return View(new PrescriptionViewModel
            {
                Name = TestDatabasePleaseDelete.Doctors.ElementAt(indexOfDoctor)
                    .Prescriptions.ElementAt(indexOfPrescription).Name,
                Medicines = TestDatabasePleaseDelete.Doctors.ElementAt(indexOfDoctor)
                    .Prescriptions.ElementAt(indexOfPrescription).Medicines
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
            TestDatabasePleaseDelete.Doctors.ElementAt(IndexOfDoctor)
                .Prescriptions.ElementAt(IndexOfPrescription)
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
