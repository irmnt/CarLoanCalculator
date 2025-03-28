using Microsoft.EntityFrameworkCore;

namespace CarLoanCalculator.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LoanDetails> LoanDetails { get; set; }
    }
}
