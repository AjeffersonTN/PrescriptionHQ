using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionHQ.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "You must add a drug name.")]       
        public string Drug { get; set; }

        [Required(ErrorMessage = "You must add a dose for this medication.")]
        public string Dosage { get; set; }

        [Required(ErrorMessage = "You must add a quantity for this medication.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "You must add a frequency for this medication.")]
        public string Frequency { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateFilled { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Prescribed Date")]
        public DateTime DatePrescribed { get; set; }

        [Display(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }
      
        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
