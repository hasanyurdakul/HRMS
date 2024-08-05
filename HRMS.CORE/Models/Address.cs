namespace HRMS.CORE;

public class Address
{
    public int AddressId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int? CompanyId { get; set; }
    public int? EmployeeId { get; set; }

    // Navigation properties
    public Company? Company { get; set; }
    public Employee? Employee { get; set; }
}
