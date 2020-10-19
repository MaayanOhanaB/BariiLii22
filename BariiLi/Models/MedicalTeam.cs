using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLi.Models
{
    public class MedicalTeam
    {
        //Avoiding automatic numbering
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLengthAttribute(9)]
        [MaxLengthAttribute(9)]
        [Key]
        [Display(Name = "Medical Team Id")]
        public string MTId { get; set; }
        [Display(Name = "Full Name")]
        public string fullName { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Specialization")]
        public string specialization { get; set; }
        [Display(Name = "Availability")]
        public DateTime availability { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "Previous Exprience")]
        public int previousExprience { get; set; }

        public ICollection<AppointmentSystems> appointments { get; set; }
    }
}
