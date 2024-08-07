using System;

namespace HRMS.CORE.DTOs;

public class CreateAddressDTO
{
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}
