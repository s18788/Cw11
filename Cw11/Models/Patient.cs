using System;
using System.Collections.Generic;

namespace Cw11.Models
{
    public class Patient
    {

        public Patient()
        {
            PrescriptionsNavigation = new HashSet<Prescription>();
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        public virtual ICollection<Prescription> PrescriptionsNavigation { get; set; }

    }
}
