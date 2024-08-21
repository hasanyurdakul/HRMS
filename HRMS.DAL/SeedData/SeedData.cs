using HRMS.CORE;
using HRMS.DAL;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.NationalHolidays.Any())
        {
            return;   // Already seeded
        }

        context.NationalHolidays.AddRange(
                new NationalHoliday
                {
                    Name = "Yeni Yıl",
                    StartDate = DateTime.Parse("2024-01-01 00:00:00"),
                    EndDate = DateTime.Parse("2024-01-01 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "23 Nisan Ulusal Egemenlik ve Çocuk Bayramı",
                    StartDate = DateTime.Parse("2024-04-23 00:00:00"),
                    EndDate = DateTime.Parse("2024-04-23 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "1 Mayıs Emek ve Dayanışma Günü",
                    StartDate = DateTime.Parse("2024-05-01 00:00:00"),
                    EndDate = DateTime.Parse("2024-05-01 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "19 Mayıs Atatürk'ü Anma, Gençlik ve Spor Bayramı",
                    StartDate = DateTime.Parse("2024-05-19 00:00:00"),
                    EndDate = DateTime.Parse("2024-05-19 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Ramazan Bayramı Arifesi",
                    StartDate = DateTime.Parse("2024-04-09 00:00:00"),
                    EndDate = DateTime.Parse("2024-04-09 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Ramazan Bayramı 1. Gün",
                    StartDate = DateTime.Parse("2024-04-10 00:00:00"),
                    EndDate = DateTime.Parse("2024-04-10 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Ramazan Bayramı 2. Gün",
                    StartDate = DateTime.Parse("2024-04-11 00:00:00"),
                    EndDate = DateTime.Parse("2024-04-11 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Ramazan Bayramı 3. Gün",
                    StartDate = DateTime.Parse("2024-04-12 00:00:00"),
                    EndDate = DateTime.Parse("2024-04-12 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Kurban Bayramı Arifesi",
                    StartDate = DateTime.Parse("2024-06-16 00:00:00"),
                    EndDate = DateTime.Parse("2024-06-16 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Kurban Bayramı 1. Gün",
                    StartDate = DateTime.Parse("2024-06-17 00:00:00"),
                    EndDate = DateTime.Parse("2024-06-17 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Kurban Bayramı 2. Gün",
                    StartDate = DateTime.Parse("2024-06-18 00:00:00"),
                    EndDate = DateTime.Parse("2024-06-18 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Kurban Bayramı 3. Gün",
                    StartDate = DateTime.Parse("2024-06-19 00:00:00"),
                    EndDate = DateTime.Parse("2024-06-19 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Kurban Bayramı 4. Gün",
                    StartDate = DateTime.Parse("2024-06-20 00:00:00"),
                    EndDate = DateTime.Parse("2024-06-20 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "15 Temmuz Demokrasi ve Milli Birlik Günü",
                    StartDate = DateTime.Parse("2024-07-15 00:00:00"),
                    EndDate = DateTime.Parse("2024-07-15 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "30 Ağustos Zafer Bayramı",
                    StartDate = DateTime.Parse("2024-08-30 00:00:00"),
                    EndDate = DateTime.Parse("2024-08-30 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "29 Ekim Cumhuriyet Bayramı",
                    StartDate = DateTime.Parse("2024-10-29 00:00:00"),
                    EndDate = DateTime.Parse("2024-10-29 23:59:59")
                },
                new NationalHoliday
                {
                    Name = "Yeni Yıl",
                    StartDate = DateTime.Parse("2025-01-01 00:00:00"),
                    EndDate = DateTime.Parse("2025-01-01 23:59:59")
                },
            new NationalHoliday
            {
                Name = "23 Nisan Ulusal Egemenlik ve Çocuk Bayramı",
                StartDate = DateTime.Parse("2025-04-23 00:00:00"),
                EndDate = DateTime.Parse("2025-04-23 23:59:59")
            },
            new NationalHoliday
            {
                Name = "1 Mayıs Emek ve Dayanışma Günü",
                StartDate = DateTime.Parse("2025-05-01 00:00:00"),
                EndDate = DateTime.Parse("2025-05-01 23:59:59")
            },
            new NationalHoliday
            {
                Name = "19 Mayıs Atatürk'ü Anma, Gençlik ve Spor Bayramı",
                StartDate = DateTime.Parse("2025-05-19 00:00:00"),
                EndDate = DateTime.Parse("2025-05-19 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Ramazan Bayramı Arifesi",
                StartDate = DateTime.Parse("2025-03-29 00:00:00"),
                EndDate = DateTime.Parse("2025-03-29 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Ramazan Bayramı 1. Gün",
                StartDate = DateTime.Parse("2025-03-30 00:00:00"),
                EndDate = DateTime.Parse("2025-03-30 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Ramazan Bayramı 2. Gün",
                StartDate = DateTime.Parse("2025-03-31 00:00:00"),
                EndDate = DateTime.Parse("2025-03-31 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Ramazan Bayramı 3. Gün",
                StartDate = DateTime.Parse("2025-04-01 00:00:00"),
                EndDate = DateTime.Parse("2025-04-01 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Kurban Bayramı Arifesi",
                StartDate = DateTime.Parse("2025-06-06 00:00:00"),
                EndDate = DateTime.Parse("2025-06-06 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Kurban Bayramı 1. Gün",
                StartDate = DateTime.Parse("2025-06-07 00:00:00"),
                EndDate = DateTime.Parse("2025-06-07 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Kurban Bayramı 2. Gün",
                StartDate = DateTime.Parse("2025-06-08 00:00:00"),
                EndDate = DateTime.Parse("2025-06-08 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Kurban Bayramı 3. Gün",
                StartDate = DateTime.Parse("2025-06-09 00:00:00"),
                EndDate = DateTime.Parse("2025-06-09 23:59:59")
            },
            new NationalHoliday
            {
                Name = "Kurban Bayramı 4. Gün",
                StartDate = DateTime.Parse("2025-06-10 00:00:00"),
                EndDate = DateTime.Parse("2025-06-10 23:59:59")
            },
            new NationalHoliday
            {
                Name = "15 Temmuz Demokrasi ve Milli Birlik Günü",
                StartDate = DateTime.Parse("2025-07-15 00:00:00"),
                EndDate = DateTime.Parse("2025-07-15 23:59:59")
            },
            new NationalHoliday
            {
                Name = "30 Ağustos Zafer Bayramı",
                StartDate = DateTime.Parse("2025-08-30 00:00:00"),
                EndDate = DateTime.Parse("2025-08-30 23:59:59")
            },
            new NationalHoliday
            {
                Name = "29 Ekim Cumhuriyet Bayramı",
                StartDate = DateTime.Parse("2025-10-29 00:00:00"),
                EndDate = DateTime.Parse("2025-10-29 23:59:59")
            }
            );
        context.SaveChanges();



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
                    isActive = true
                },
                Department = new Department
                {
                    Name = "Human Resources",
                    CompanyId = 1,
                    isActive = true
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
