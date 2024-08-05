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

        //############################################################################################################
        // Seed data for Genders
        context.Genders.AddRange(
            new Gender { GenderName = "Male" },
            new Gender { GenderName = "Female" }
        );
        context.SaveChanges();
        //############################################################################################################
        //############################################################################################################
        // Seed data for Leave Types
        context.LeaveTypes.AddRange(
            new LeaveType { LeaveTypeName = "Sick Leave" },
            new LeaveType { LeaveTypeName = "Vacation Leave" },
            new LeaveType { LeaveTypeName = "Personal Leave" }
        );
        context.SaveChanges();
        //############################################################################################################
        //############################################################################################################
        // Seed data for Request Statuses
        context.RequestStatuses.AddRange(
            new RequestStatus { RequestStatusName = "Pending" },
            new RequestStatus { RequestStatusName = "Approved" },
            new RequestStatus { RequestStatusName = "Rejected" }
        );
        context.SaveChanges();
        //############################################################################################################
        //############################################################################################################
        // Seed data for Education 
        context.Educations.AddRange(
            new Education { EducationLevel = "High School" },
            new Education { EducationLevel = "Bachelor's Degree" },
            new Education { EducationLevel = "Master's Degree" },
            new Education { EducationLevel = "Doctorate" }
        );
        context.SaveChanges();
        //############################################################################################################


        // // Seed data for Addresses
        // context.Addresses.AddRange(
        //     new Address
        //     {
        //         StreetAddress = "123 Main St",
        //         City = "Anytown",
        //         State = "NY",
        //         PostalCode = "12345",
        //         Country = "USA"
        //     },
        //     new Address
        //     {
        //         StreetAddress = "Birlik Mahallesi",
        //         City = "İstanbul",
        //         State = "Esenler",
        //         PostalCode = "34230",
        //         Country = "TR"
        //     }
        // );
        // context.SaveChanges();


        // Seed data for Companies
        context.Companies.AddRange(
            new Company
            {
                CompanyName = "Sample Company 1",
                CompanyEmail = "info@samplewcompany1.com",
                CompanyPhoneNumber = "+1 (555) 555-1212",
                CompanyLogoUrl = "https://via.placeholder.com/150",
                Address = new Address
                {
                    StreetAddress = "123 Main St",
                    City = "Anytown",
                    State = "NY",
                    PostalCode = "12345",
                    Country = "USA",
                    CompanyId = 1
                }
            }
        );
        context.SaveChanges();

        // Seed data for Resumes
        context.Resumes.AddRange(
            new Resume { ResumePath = "https://via.placeholder.com/150", CompanyId = 1 }
        );
        context.SaveChanges();

        // Seed data for Jobs
        context.Jobs.AddRange(
            new Job { JobTitle = "Human Resources Manager", CompanyId = 1 },
            new Job { JobTitle = "Marketing Specialist", CompanyId = 1 }
        );
        context.SaveChanges();

        // Seed data for Departments
        context.Departments.AddRange(
            new Department { DepartmentName = "Human Resources", CompanyId = 1 },
            new Department { DepartmentName = "Marketing", CompanyId = 1 }
        );
        context.SaveChanges();

        // Seed data for Salaries
        context.Salaries.AddRange(
            new Salary { Amount = 50000, EmployeeId = 1 }
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
                EducationId = 2,
                GenderId = 1,
                CompanyId = 1,
                JobId = 1,
                DepartmentId = 1,
                ManagerId = 1,
                AddressId = 1,
                SalaryId = 1,
                isActive = true,
                ResumeId = 1,
                Address = new Address
                {
                    StreetAddress = "44444 Main St",
                    City = "Anytown",
                    State = "NY",
                    PostalCode = "12345",
                    Country = "USA"
                }
            });
        context.SaveChanges();

        // // Seed data for Companies
        // context.Companies.AddRange(
        //     new Company
        //     {
        //         CompanyName = "Sample Company 1",
        //         CompanyEmail = "info@samplecompany1.com",
        //         CompanyPhoneNumber = "+1 (555) 555-1212",
        //         CompanyLogoUrl = "https://via.placeholder.com/150",

        //     },
        //     new Company
        //     {
        //         CompanyName = "Sample Company 2",
        //         CompanyEmail = "info@samplecompany2.com",
        //         CompanyPhoneNumber = "+1 (555) 555-2323",
        //         CompanyLogoUrl = "https://via.placeholder.com/150"
        //     }
        // );
        // context.SaveChanges();

        // // Seed data for Departments (assuming companies are already created)
        // var company1 = context.Companies.FirstOrDefault(c => c.CompanyName == "Sample Company 1");
        // var company2 = context.Companies.FirstOrDefault(c => c.CompanyName == "Sample Company 2");
        // context.SaveChanges();

        // context.Departments.AddRange(
        //     new Department { DepartmentName = "Human Resources", Company = company1 },
        //     new Department { DepartmentName = "Marketing", Company = company1 },
        //     new Department { DepartmentName = "Engineering", Company = company2 },
        //     new Department { DepartmentName = "Sales", Company = company2 }
        // );
        // context.SaveChanges();

        // // Sample employees (assuming departments and genders are already created)
        // context.Employees.AddRange(
        //     new Employee
        //     {
        //         FirstName = "John",
        //         LastName = "Doe",
        //         Email = "john.doe@samplecompany1.com",
        //         HireDate = DateTime.Now.AddYears(-2),
        //         BirthDate = DateTime.Now.AddYears(-30),
        //         PhoneNumber = "+1 (555) 555-4545",
        //         GenderId = context.Genders.FirstOrDefault(g => g.GenderName == "Male").GenderId,
        //         CompanyId = company1.CompanyId,
        //         DepartmentId = context.Departments.FirstOrDefault(d => d.DepartmentName == "Human Resources").DepartmentId,
        //         isActive = true
        //     },
        //     new Employee
        //     {
        //         FirstName = "Jane",
        //         LastName = "Smith",
        //         Email = "jane.smith@samplecompany2.com",
        //         HireDate = DateTime.Now.AddYears(-1),
        //         BirthDate = DateTime.Now.AddYears(-25),
        //         PhoneNumber = "+1 (555) 555-5656",
        //         GenderId = context.Genders.FirstOrDefault(g => g.GenderName == "Female").GenderId,
        //         CompanyId = company2.CompanyId,
        //         DepartmentId = context.Departments.FirstOrDefault(d => d.DepartmentName == "Marketing").DepartmentId,
        //         isActive = true
        //     }
        // );

        // context.SaveChanges();
    }
}
