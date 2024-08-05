namespace HRMS.CORE;

public interface IAddressRepository : IRepository<Address>
{
    Task<Address> UpdateAsync(Address address);
    Task<Address> DeleteAsync(Address address);

}
