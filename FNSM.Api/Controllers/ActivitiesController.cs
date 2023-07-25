using FNSM.Api.Repositories.Interfaces;
using FNSM.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace FNSM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivitiesController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            try
            {
                return Ok(await _activityRepository.GetActivities());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Activity>> GetActivityById(int id)
        {
            try
            {
                var activity = await _activityRepository.GetActivityById(id);

                if (activity == null) { return NotFound(); }

                return Ok(activity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody] Activity activity)
        {
            try
            {
                if (activity == null) { return BadRequest(); }

                var addedActivity = await _activityRepository.AddActivity(activity);

                return CreatedAtAction(nameof(AddActivity), new { id = addedActivity.Id }, addedActivity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] Activity activity)
        {
            try
            {

                if (id != activity.Id) { return BadRequest("Activity Id mismatch"); }

                var activityToUpdate = await _activityRepository.UpdateActivity(activity);

                if (activityToUpdate == null) { return NotFound($"Activity with Id = {id} not found"); }

                return Ok(activityToUpdate);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            try
            {
                var activityToDelete = await _activityRepository.GetActivityById(id);

                if (activityToDelete == null) { return NotFound($"Activity with Id = {id} not found"); }

                await _activityRepository.DeleteActivity(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
