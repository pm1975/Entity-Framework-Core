using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lekadex.Controllers
{
    public class PrescriptionController : Controller
    {
        private int IndexOfDoctor { get; set; }
        public PrescriptionController()
        {

        }

        public IActionResult Index(int indexOfDoctor, string filterString)
        {
            IndexOfDoctor = indexOfDoctor;

            if (string.IsNullOrEmpty(filterString))
            {
                return View(TestDatabasePleaseDelete.Doctors.ElementAt(indexOfDoctor));
            }

            return View(new DoctorViewModel
            {
                Name = TestDatabasePleaseDelete.Doctors.ElementAt(indexOfDoctor).Name,
                Prescriptions = TestDatabasePleaseDelete.Doctors.ElementAt(indexOfDoctor)
                    .Prescriptions.Where(x => x.Name.Contains(filterString)).ToList()
            });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVm)
        {
            TestDatabasePleaseDelete.Doctors.ElementAt(IndexOfDoctor)
                .Prescriptions.Add(prescriptionVm);

            //wrócimy z powrotem do Index
            return RedirectToAction("Index");
        }


        public IActionResult View(int indexOfPrescription)
        {
            return RedirectToAction("Index", "Medicine", new
            {
                indexOfDoctor = IndexOfDoctor,
                indexOfPrescription = indexOfPrescription
            });
        }

        public IActionResult Delete(int indexOfPrescription)
        {
            return View();
        }
    }
}
