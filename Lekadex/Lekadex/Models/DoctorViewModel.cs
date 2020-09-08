﻿using System.Collections.Generic;

namespace Lekadex
{
    public class DoctorViewModel
    {
        //public string Name { get; set; }
        //public List<PrescriptionViewModel> Prescriptions { get; set; }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkYears { get; set; }
        public bool IsAbleToMakePrescriptions { get; set; }
        public List<PrescriptionViewModel> Prescriptions { get; set; }
    }
}