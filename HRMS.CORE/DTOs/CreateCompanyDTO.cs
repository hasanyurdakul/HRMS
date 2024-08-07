using HRMS.CORE.DTOs;

namespace HRMS.CORE;

public class CreateCompanyDTO
{
    public int? CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyLogoUrl { get; set; }
    public CreateAddressDTO createAddressDTO { get; set; }
}
