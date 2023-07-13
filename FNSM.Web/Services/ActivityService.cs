using FNSM.DataLayer;
using FNSM.Web.Services.Interfaces;

namespace FNSM.Web.Services
{
    public class ActivityService : IActivityService
    {
        private readonly HttpClient _httpClient;

        public ActivityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _httpClient.GetFromJsonAsync<Activity[]>("api/activities");
        }
    }
}
