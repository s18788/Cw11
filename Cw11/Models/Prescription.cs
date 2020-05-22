using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Prescription
    {

        public Prescription()
        {
            Prescription_MedicamentNavigation = new HashSet<Prescription_Medicament>();
        }

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual Patient IdPatientNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual ICollection<Prescription_Medicament> Prescription_MedicamentNavigation { get; set; }

    }
}
