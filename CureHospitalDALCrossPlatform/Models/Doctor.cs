using System;
using System.Collections.Generic;

namespace CureHospitalDALCrossPlatform.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            DoctorSpecializations = new HashSet<DoctorSpecialization>();
            Surgeries = new HashSet<Surgery>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;

        public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
        public virtual ICollection<Surgery> Surgeries { get; set; }
    }
}
