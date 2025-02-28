using System;
using System.Collections.Generic;

namespace CureHospitalDALCrossPlatform.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            DoctorSpecializations = new HashSet<DoctorSpecialization>();
            Surgeries = new HashSet<Surgery>();
        }

        public string SpecializationCode { get; set; } = null!;
        public string SpecializationName { get; set; } = null!;

        public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
        public virtual ICollection<Surgery> Surgeries { get; set; }
    }
}
