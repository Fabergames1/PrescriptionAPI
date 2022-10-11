using Microsoft.EntityFrameworkCore;

namespace PrescriptionAPI.Models.Data
{
    public class PrescriptionDataContext :DbContext
    {
        public PrescriptionDataContext(DbContextOptions<PrescriptionDataContext> options)
            : base(options)
        {
                
        }   

        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
