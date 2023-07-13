using FNSM.DataLayer;

namespace FNSM.Web.Services.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetActivities();
    }
}
