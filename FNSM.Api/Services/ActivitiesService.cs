using FNSM.Api.Repositories.Interfaces;
using FNSM.Api.Services.Interfaces;
using FNSM.DataLayer;

namespace FNSM.Api.Services
{
    public class ActivitiesService : IActivitiesService
	{
		private readonly IActivitiesRepository _activitiesRepository;

		public ActivitiesService(IActivitiesRepository activitiesRepository)
		{
			_activitiesRepository = activitiesRepository;
		}

		public async Task<Activity> AddActivity(Activity activity)
		{
			return await _activitiesRepository.AddActivity(activity);
		}

		public async Task DeleteActivity(int id)
		{
			await _activitiesRepository.DeleteActivity(id);
		}

		public async Task<IEnumerable<Activity>> GetActivities()
		{
			return await _activitiesRepository.GetActivities();
		}

		public async Task<Activity> GetActivityById(int id)
		{
			return await _activitiesRepository.GetActivityById(id);
		}

		public async Task<Activity> UpdateActivity(Activity activity)
		{
			return await _activitiesRepository.UpdateActivity(activity);
		}
	}
}
