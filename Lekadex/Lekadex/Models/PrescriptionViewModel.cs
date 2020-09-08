using System;
using System.Collections.Generic;

namespace Lekadex
{
    public class PrescriptionViewModel
    {
        //public string Name { get; set; }
        //public List<MedicineViewModel> Medicines { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public List<MedicineViewModel> Medicines { get; set; }
    }
}
