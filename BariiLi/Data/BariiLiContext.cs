using BariiLi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BariiLi.Data
{
    public class BariiLiContext : DbContext
    {
        public BariiLiContext(DbContextOptions<BariiLiContext> options)
            :base(options)
        {

        }

        public DbSet<MedicalTeam> MedicalTeams { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<AppointmentSystems> AppointmentSystems { get; set; }
    }
}
