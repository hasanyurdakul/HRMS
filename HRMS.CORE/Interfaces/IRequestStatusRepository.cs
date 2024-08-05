namespace HRMS.CORE;

public interface IRequestStatusRepository : IRepository<RequestStatus>
{
    Task<RequestStatus> UpdateAsync(RequestStatus requestStatus);
    Task<RequestStatus> DeleteAsync(RequestStatus requestStatus);

}
