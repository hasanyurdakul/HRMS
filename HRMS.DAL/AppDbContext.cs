using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRMS.CORE;

namespace HRMS.DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
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


            modelBuilder.Entity<Resume>()
                    .HasOne(e => e.Employee)
                    .WithOne(e => e.Resume)
                    .HasForeignKey<Resume>(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Department)
                    .WithMany(e => e.Employees)
                    .HasForeignKey(e => e.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Job)
                    .WithMany(e => e.Employees)
                    .HasForeignKey(e => e.JobId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
