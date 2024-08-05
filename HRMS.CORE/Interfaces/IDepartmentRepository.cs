namespace HRMS.CORE;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<Department> UpdateAsync(Department department);
    Task<Department> DeleteAsync(Department department);
}
