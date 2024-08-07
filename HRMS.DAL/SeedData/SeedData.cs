using HRMS.CORE;
using HRMS.DAL;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        // Check if there are any existing records
        if (context.Employees.Any())
        {
            return;   // Already seeded
        }

        // + Seed data for Genders
        context.Genders.AddRange(
            new Gender { Name = "Male" },
            new Gender { Name = "Female" }
        );
        context.SaveChanges();

        // + Seed data for Leave Types
        context.LeaveTypes.AddRange(
            new LeaveType { Name = "Sick Leave" },
            new LeaveType { Name = "Vacation Leave" },
            new LeaveType { Name = "Personal Leave" }
        );
        context.SaveChanges();

        // + Seed data for Request Statuses
        context.RequestStatuses.AddRange(
            new RequestStatus { Name = "Pending" },
            new RequestStatus { Name = "Approved" },
            new RequestStatus { Name = "Rejected" }
        );
        context.SaveChanges();

        // + Seed data for Education 
        context.EducationLevels.AddRange(
            new EducationLevel { Name = "High School" },
            new EducationLevel { Name = "Bachelor's Degree" },
            new EducationLevel { Name = "Master's Degree" },
            new EducationLevel { Name = "Doctorate" }
        );
        context.SaveChanges();


        // + Seed data for Companies
        context.Companies.AddRange(
            new Company
            {
                Name = "Sample Company 1",
                Email = "info@samplewcompany1.com",
                PhoneNumber = "+1 (555) 555-1212",
                LogoUrl = "https://via.placeholder.com/150",
                Address = new Address
                {
                    StreetAddress = "123 Main St",
                    City = "Anytown",
                    State = "NY",
                    PostalCode = "12345",
                    Country = "USA",
                }
            }
        );
        context.SaveChanges();

        // Seed data for Employees
        context.Employees.AddRange(
            new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@samplecompany1.com",
                HireDate = DateTime.Now.AddYears(-2),
                BirthDate = DateTime.Now.AddYears(-30),
                PhoneNumber = "+1 (555) 555-4545",
                RemainingLeaveDays = 14,
                EducationLevelId = 2,
                GenderId = 1,
                CompanyId = 1,
                JobId = 1,
                DepartmentId = 1,
                ManagerEmployeeId = 1,
                isActive = true,
                Address = new Address
                {
                    StreetAddress = "44444 Main St",
                    City = "Anytown",
                    State = "NY",
                    PostalCode = "12345",
                    Country = "USA"
                },
                Resume = new Resume
                {
                    Path = "https://via.placeholder.com/150",
                    CompanyId = 1,
                    EmployeeId = 1
                },
                Job = new Job
                {
                    Title = "Human Resources Manager",
                    CompanyId = 1,
                },
                Department = new Department
                {
                    Name = "Human Resources",
                    CompanyId = 1,
                },
                Salary = new Salary
                {
                    Amount = 50000,
                    EmployeeId = 1
                }
            });
        context.SaveChanges();


    }
}
