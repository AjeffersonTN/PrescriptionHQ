using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PrescriptionHQ.Models
{
    public class Pharmacy: IdentityUser
    {
        [Key]
        public string PharmacyId { get; set; }

        [Required(ErrorMessage = "You must your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "You must provide a street address.")]
        [Display(Name = "Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "You must provide a city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "You must provide a state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "You must provide a valid zip code.")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "You must provide a phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "You must provide a valid email.")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        public virtual ICollection<Refill> Refills { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
