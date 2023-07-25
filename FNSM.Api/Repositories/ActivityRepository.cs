using FNSM.Api.Repositories.Interfaces;
using FNSM.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace FNSM.Api.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _appDbContext;

        public ActivityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Activity> AddActivity(Activity activity)
        {
            var result = await _appDbContext.Activities.AddAsync(activity);

            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteActivity(int id)
        {
            var result = await _appDbContext.Activities
                .FirstOrDefaultAsync(a => a.Id == id);

            if (result != null)
            {
                _appDbContext.Activities.Remove(result);				
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _appDbContext.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityById(int id)
        {
            return await _appDbContext.Activities.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Activity> UpdateActivity(Activity activity)
        {
            var activityToUpdate = await _appDbContext.Activities
                .FirstOrDefaultAsync(a => a.Id == activity.Id);
            
            if (activityToUpdate != null)
            {
                activityToUpdate.Description = activity.Description;
                activityToUpdate.CreatedDate = activity.CreatedDate;

                await _appDbContext.SaveChangesAsync();

                return activityToUpdate;
            }

            return null;
        }
    }
}
