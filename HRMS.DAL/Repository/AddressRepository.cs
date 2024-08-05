using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Address> DeleteAsync(Address address)
    {
        _context.Entry(address).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address> UpdateAsync(Address address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
        return address;
    }
}
