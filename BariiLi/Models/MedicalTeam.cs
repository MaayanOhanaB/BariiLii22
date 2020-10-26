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
        public MedicalTeam() {}
        public MedicalTeam(string mTId, string fullName, string gender, string specialization, DateTime availability, string location, int previousExprience) 
        {
            this.MTId = mTId;
            this.fullName = fullName;
            this.gender = gender;
            this.specialization = specialization;
            this.availability = availability;
            this.location = location;
            this.previousExprience = previousExprience;
        }
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
        //Displays just the time
        [DataType(DataType.Time)]
        public DateTime availability { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "Previous Exprience")]
        public int previousExprience { get; set; }

        public ICollection<AppointmentSystems> appointments { get; set; }
    }
}
