using FNSM.DataLayer;

namespace FNSM.Api.Services.Interfaces
{
    public interface IActivitiesService
    {
        Task<Activity> AddActivity(Activity activity);
        Task DeleteActivity(int id);
        Task<IEnumerable<Activity>> GetActivities();
        Task<Activity> GetActivityById(int id);
        Task<Activity> UpdateActivity(Activity activity);
    }
}