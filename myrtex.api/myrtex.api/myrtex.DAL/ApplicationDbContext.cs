using Microsoft.EntityFrameworkCore;
using myrtex.DAL.Configuring;
using myrtex.Domain.Models;

namespace myrtex.DAL
{
    /// <summary>
    /// Класс контекста БД 
    /// </summary>
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiure());
        }
    }
}