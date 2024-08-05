namespace HRMS.CORE;

public interface IEventRepository : IRepository<Event>
{
    Task<Event> UpdateAsync(Event @event);
    Task<Event> DeleteAsync(Event @event);

}
