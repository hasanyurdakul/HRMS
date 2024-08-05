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

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Employee)
                .WithOne(e => e.Address)
                .HasForeignKey<Address>(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Company)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company configuration
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Company)
                .HasForeignKey<Company>(c => c.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Departments)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Events)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Resumes)
                .WithOne(r => r.Company)
                .HasForeignKey(r => r.ResumeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Users)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Department configuration
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Company)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Education configuration
            modelBuilder.Entity<Education>()
                .HasMany(ed => ed.Employees)
                .WithOne(e => e.Education)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee configuration
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Gender)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Job)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salary>(s => s.SalaryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Expenses)
                .WithOne(ex => ex.Employee)
                .HasForeignKey(ex => ex.ExpenseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Leaves)
                .WithOne(l => l.Employee)
                .HasForeignKey(l => l.LeaveId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Resume)
                .WithOne(r => r.Employee)
                .HasForeignKey<Resume>(r => r.ResumeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<User>(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Event configuration
            modelBuilder.Entity<Event>()
                .HasOne(ev => ev.User)
                .WithMany(u => u.Events)
                .HasForeignKey(ev => ev.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Expense configuration
            modelBuilder.Entity<Expense>()
                .HasOne(ex => ex.RequestStatus)
                .WithMany(rs => rs.Expenses)
                .HasForeignKey(ex => ex.RequestStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Gender configuration
            modelBuilder.Entity<Gender>()
                .HasMany(g => g.Employees)
                .WithOne(e => e.Gender)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Job configuration
            modelBuilder.Entity<Job>()
                .HasMany(j => j.Employees)
                .WithOne(e => e.Job)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Leave configuration
            modelBuilder.Entity<Leave>()
                .HasOne(l => l.LeaveType)
                .WithMany(lt => lt.Leaves)
                .HasForeignKey(l => l.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leave>()
                .HasOne(l => l.RequestStatus)
                .WithMany(rs => rs.Leaves)
                .HasForeignKey(l => l.RequestStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // LeaveType configuration
            modelBuilder.Entity<LeaveType>()
                .HasMany(lt => lt.Leaves)
                .WithOne(l => l.LeaveType)
                .HasForeignKey(l => l.LeaveId)
                .OnDelete(DeleteBehavior.Restrict);

            // RequestStatus configuration
            modelBuilder.Entity<RequestStatus>()
                .HasMany(rs => rs.Expenses)
                .WithOne(ex => ex.RequestStatus)
                .HasForeignKey(ex => ex.ExpenseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(rs => rs.Leaves)
                .WithOne(l => l.RequestStatus)
                .HasForeignKey(l => l.LeaveId)
                .OnDelete(DeleteBehavior.Restrict);

            // Resume configuration
            modelBuilder.Entity<Resume>()
                .HasOne(r => r.Employee)
                .WithOne(e => e.Resume)
                .HasForeignKey<Resume>(r => r.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resume>()
                .HasOne(r => r.Company)
                .WithMany(c => c.Resumes)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Salary configuration
            modelBuilder.Entity<Salary>()
                .HasOne(s => s.Employee)
                .WithOne(e => e.Salary)
                .HasForeignKey<Salary>(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // User configuration
            modelBuilder.Entity<User>()
                .HasMany(u => u.Events)
                .WithOne(ev => ev.User)
                .HasForeignKey(ev => ev.EventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
