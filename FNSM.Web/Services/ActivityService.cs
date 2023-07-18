using FNSM.DataLayer;
using FNSM.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<Activity> GetActivityById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Activity>($"api/activities/{id}");
        }

		public async Task<HttpResponseMessage> AddActivity(Activity activity)
		{
            activity.CreatedDate = DateTime.Now;

			var content = new StringContent(JsonConvert.SerializeObject(activity), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("api/activities", content);

			return response;
		}
	}
}
