namespace HRMS.CORE;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<Expense> UpdateAsync(Expense expense);
    Task<Expense> DeleteAsync(Expense expense);

}
