﻿using System;
using System.Collections.Generic;

namespace CureHospitalDALCrossPlatform.Models
{
    public partial class Surgery
    {
        public int SurgeryId { get; set; }
        public int DoctorId { get; set; }
        public DateTime SurgeryDate { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public string SurgeryCategory { get; set; } = null!;

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Specialization SurgeryCategoryNavigation { get; set; } = null!;
    }
}
