using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lekadex.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index(string filterString)
        {
            if (string.IsNullOrEmpty(filterString))
            {
                return View(TestDatabasePleaseDelete.Doctors);
            }

            return View(TestDatabasePleaseDelete.Doctors
                .Where(x => x.Name.Contains(filterString)).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorViewModel doctorVm)
        {
            TestDatabasePleaseDelete.Doctors.Add(doctorVm);

            //wrócimy z powrotem do Index
            return RedirectToAction("Index");
        }

        public IActionResult View(int indexOfDoctor)
        {
            return RedirectToAction("Index", "Prescription", new { indexOfDoctor = indexOfDoctor });
        }

        public IActionResult Delete(int indexOfDoctor)
        {
            return View(TestDatabasePleaseDelete.Doctors);
        }
    }
}
