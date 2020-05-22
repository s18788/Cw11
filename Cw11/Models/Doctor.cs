using System.Collections.Generic;

namespace Cw11.Models
{
    public class Doctor
    {

        public Doctor()
        {
            PrescriptionsNavigation = new HashSet<Prescription>();
        }

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public virtual ICollection<Prescription> PrescriptionsNavigation { get; set; }


    }
}
