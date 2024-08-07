using HRMS.CORE;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    private readonly AppDbContext _context;

    public CompanyRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company> GetByIdAsync(int id)
    {
        return await _context.Companies.FindAsync(id);
    }

    public async Task AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Company company)
    {
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }
}
