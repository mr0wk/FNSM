using FNSM.DataLayer;

namespace FNSM.Api.Repositories.Interfaces
{
    public interface IActivitiesRepository
    {
        Task<IEnumerable<Activity>> GetActivities();
        Task<Activity> GetActivityById(int id);
        Task<Activity> AddActivity(Activity activity);
        Task<Activity> UpdateActivity(Activity activity);
        Task DeleteActivity(int id);
    }
}
