using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAPITrail.Models
{
    public class ExaminationContext : DbContext
    {
        public ExaminationContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<Examination> Examinations { get; set; }
    }
}
