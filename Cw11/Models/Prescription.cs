using System;
using System.Collections.Generic;

namespace Cw11.Models
{
    public class Prescription
    {

        public Prescription()
        {
            PrescriptionMedicamentNavigation = new HashSet<PrescriptionMedicament>();
        }

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual Patient IdPatientNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicamentNavigation { get; set; }

    }
}
