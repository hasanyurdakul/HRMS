// using System.Text;
// using HRMS.BUSINESS;
// using HRMS.CORE;
// using HRMS.DAL;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.OpenApi.Models;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
//     .AddEntityFrameworkStores<AppDbContext>()
//     .AddDefaultTokenProviders();


// //Repositories
// builder.Services.AddScoped<IAddressRepository, AddressRepository>();
// builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
// builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
// builder.Services.AddScoped<IEducationRepository, EducationRepository>();
// builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
// builder.Services.AddScoped<IEventRepository, EventRepository>();
// builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
// builder.Services.AddScoped<IGenderRepository, GenderRepository>();
// builder.Services.AddScoped<IJobRepository, JobRepository>();
// builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
// builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
// builder.Services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
// builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
// builder.Services.AddScoped<IRoleRepository, RoleRepository>();
// builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<INationalHolidayRepository, NationalHolidayRepository>();

// //Services
// builder.Services.AddScoped<IEmployeeService, EmployeeService>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<ILeaveService, LeaveService>();
// builder.Services.AddScoped<ICompanyService, CompanyService>();
// builder.Services.AddScoped<IEventService, EventService>();
// builder.Services.AddScoped<ICalendarService, CalendarService>();
// builder.Services.AddScoped<ITokenService, TokenService>();




// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });



// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMS API", Version = "v1" });
//     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
//         Name = "Authorization",
//         In = ParameterLocation.Header,
//         Type = SecuritySchemeType.ApiKey,
//         Scheme = "Bearer"
//     });
//     c.AddSecurityRequirement(new OpenApiSecurityRequirement{
//     {
//         new OpenApiSecurityScheme{
//             Reference = new OpenApiReference{
//                 Type = ReferenceType.SecurityScheme,
//                 Id = "Bearer"
//             }
//         },
//         new string[]{}
//     }});
// });



// var app = builder.Build();

// //SeedData
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     try
//     {
//         var context = services.GetRequiredService<AppDbContext>();
//         SeedData.Initialize(context);
//     }
//     catch (Exception ex)
//     {
//         var logger = services.GetRequiredService<ILogger<Program>>();
//         logger.LogError(ex, "An error occurred while seeding the database.");
//     }
// }

// using (var scope = app.Services.CreateScope())
// {
//     var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
//     var roles = new[] { "Admin", "CompanyOwner", "CompanyManager", "CompanyUser" };
//     foreach (var role in roles)
//     {
//         if (!await roleManager.RoleExistsAsync(role))
//         {
//             await roleManager.CreateAsync(new Role(role));
//         }
//     }
// }

// using (var scope = app.Services.CreateScope())
// {
//     var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
//     var user = await userManager.FindByNameAsync("admin");
//     if (user == null)
//     {
//         user = new User
//         {
//             UserName = "admin",
//             Email = "email"
//         };
//         await userManager.CreateAsync(user, "Admin123.");
//         await userManager.AddToRoleAsync(user, "Admin");
//     }
// }








// // Configure the HTTP request pipeline.

// app.UseSwagger();
// app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMS API V1");
//     });

// app.UseHttpsRedirection();

// app.UseRouting();

// app.UseAuthentication();
// app.UseAuthorization();

// app.MapControllers();

// app.Run();



using System.Text;
using HRMS.BUSINESS;
using HRMS.CORE;
using HRMS.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


//Repositories
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INationalHolidayRepository, NationalHolidayRepository>();

//Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<ITokenService, TokenService>();




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMS API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
        new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[]{}
    }});
});



var app = builder.Build();

//SeedData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        SeedData.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var roles = new[] { "Admin", "CompanyOwner", "CompanyManager", "CompanyUser" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new Role(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var user = await userManager.FindByNameAsync("admin");
    if (user == null)
    {
        user = new User
        {
            UserName = "admin",
            Email = "email"
        };
        await userManager.CreateAsync(user, "Admin123.");
        await userManager.AddToRoleAsync(user, "Admin");
    }
}








// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
// app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMS API V1");
//     });

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
