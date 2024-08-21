using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HRMS.CORE;
using System.Threading.Tasks;
using HRMS.BUSINESS;
using Microsoft.AspNetCore.Authorization;
using HRMS.API.Utility;
using HRMS.BUSINESS.Interfaces;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmployeeService _employeeService;
        private readonly IEmailService _emailService;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IEmployeeService employeeService, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _employeeService = employeeService;
            _emailService = emailService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password");
            }

            await _signInManager.SignInAsync(user, false);

            var token = await _tokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }


        [Authorize(Roles = "Admin,CompanyOwner,CompanyManager")]
        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO model)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);

            string roleToAssign;

            if (currentUserRoles.Contains("Admin"))
            {
                roleToAssign = "CompanyOwner";
            }
            else if (currentUserRoles.Contains("CompanyOwner"))
            {
                roleToAssign = "CompanyManager";
            }
            else if (currentUserRoles.Contains("CompanyManager"))
            {
                roleToAssign = "CompanyUser";
            }
            else
            {
                return Forbid("You do not have permission to create users.");
            }

            var employee = model.EmployeeId != null
                ? await _employeeService.GetEmployeeById((int)model.EmployeeId)
                : null;

            var newUser = new User
            {
                UserName = model.Username,
                Email = model.Email,
                CompanyId = model.CompanyId,
                Employee = employee
            };

            var passwordGenerator = new PasswordGenerator();
            string randomPassword = passwordGenerator.GenerateRandomPassword(10);
            Console.WriteLine("###########PASSWORD########### \n" + randomPassword);


            var result = await _userManager.CreateAsync(newUser, randomPassword);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, roleToAssign);
                // Şifreyi kullanıcıya e-posta ile gönder
                string subject = "Your new account password";
                string body = $"Hello {newUser.UserName},\n\nYour account has been created. Here is your password: {randomPassword}";
                await _emailService.SendEmailAsync(newUser.Email, subject, body);
                return Ok($"User created successfully with role: {roleToAssign}");
            }

            return BadRequest(result.Errors);
        }
    }
}
