using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionHQ.Models
{
    public class Role
    {
        public string MemberId { get; set; }

        public string DoctorId { get; set; }
        
        public int PharmacyId { get; set; }
    }
}
