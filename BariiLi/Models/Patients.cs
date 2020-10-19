using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLi.Models
{
    public class Patients
    {
        //Avoiding automatic numbering
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLengthAttribute(9)]
        [MaxLengthAttribute(9)]
        [Key]
        [Display(Name = "Patient Id")]        
        public string patientId { get; set; }
        [Display(Name ="Full Name")]
        public string fullName { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Type Of Pain")]
        public string typeOfPain { get; set; }

        public ICollection<AppointmentSystems> appointments { get; set; }
    }
}
