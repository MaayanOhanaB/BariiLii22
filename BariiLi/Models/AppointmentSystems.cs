using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLi.Models
{
    public class AppointmentSystems
    {
        [Key]
        [Display(Name = "Type Of Pain")]       
        public string typeOfPain { get; set; }
        [Display(Name = "Medical Team Id")]
        public int MTId { get; set; }
        [Display(Name = "Patient Id")]
        public int patientId { get; set; }
        [Display(Name = "Availability Queues")]
        public DateTime availabilityQueues { get; set; }

        public MedicalTeam medicalTeam { get; set; }
        public Patients patients { get; set; }
    }
}
