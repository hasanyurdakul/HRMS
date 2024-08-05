using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRMS.CORE;

namespace HRMS.DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<NationalHoliday> NationalHolidays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                       .HasOne(c => c.Address)
                       .WithOne(a => a.Company)
                       .HasForeignKey<Company>(c => c.AddressId)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                        .HasOne(a => a.Employee)
                        .WithOne(e => e.Address)
                        .HasForeignKey<Address>(a => a.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);

            // Company-Department relationship
            modelBuilder.Entity<Department>()
                        .HasOne(d => d.Company)
                        .WithMany(c => c.Departments)
                        .HasForeignKey(d => d.CompanyId)
                        .OnDelete(DeleteBehavior.Restrict);

            // Department-Employee relationship
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Department)
                        .WithMany(d => d.Employees)
                        .HasForeignKey(e => e.DepartmentId)
                        .OnDelete(DeleteBehavior.Restrict);

            // Job-Employee relationship
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Job)
                        .WithMany(j => j.Employees)
                        .HasForeignKey(e => e.JobId)
                        .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser-Employee relationship
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Employee)
                        .WithOne(e => e.User)
                        .HasForeignKey<User>(u => u.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);


            // Resume-Employee relationship
            modelBuilder.Entity<Resume>()
                        .HasOne(r => r.Employee)
                        .WithOne(e => e.Resume)
                        .HasForeignKey<Resume>(r => r.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                        .HasOne(e => e.Company)
                        .WithMany(c => c.Events)
                        .HasForeignKey(e => e.CompanyId)
                        .OnDelete(DeleteBehavior.Restrict);
            // Diğer ilişkilerde de benzer şekilde davranışı ayarlayabilirsiniz.
        }
    }
}
