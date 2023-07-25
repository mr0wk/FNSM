using FNSM.DataLayer;

namespace FNSM.Web.Services.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetActivities();
        Task<Activity> GetActivityById(int id);
        Task<HttpResponseMessage> AddActivity(Activity activity);
        Task<HttpResponseMessage> DeleteActivity(int id);
	}
}
