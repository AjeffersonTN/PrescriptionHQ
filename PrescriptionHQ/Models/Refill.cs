using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionHQ.Models
{
    public class Refill
    {
        [Key]
        public int RefillId { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RequestDate { get; set; }

        [Required]
        [Display(Name = "Status of Pickup")]
        public bool PickupStatus { get; set; }

        [Required]
        public int PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
