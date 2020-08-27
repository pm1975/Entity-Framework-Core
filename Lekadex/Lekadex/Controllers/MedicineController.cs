using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lekadex.Controllers
{
    public class MedicineController : Controller
    {
        public MedicineController()
        {

        }

        public IActionResult Index(int indexOfDoctor, int indexOfPrescription, string filterString)
        {
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

        public IActionResult Delete(int indexOfMedicine)
        {
            return View();
        }
    }
}
