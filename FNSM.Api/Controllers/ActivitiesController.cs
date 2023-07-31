using FNSM.Api.Repositories.Interfaces;
using FNSM.Api.Services.Interfaces;
using FNSM.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace FNSM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
			_activitiesService = activitiesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            try
            {
                return Ok(await _activitiesService.GetActivities());
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
                var activity = await _activitiesService.GetActivityById(id);

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

                var addedActivity = await _activitiesService.AddActivity(activity);

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

                var activityToUpdate = await _activitiesService.UpdateActivity(activity);

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
                var activityToDelete = await _activitiesService.GetActivityById(id);

                if (activityToDelete == null) { return NotFound($"Activity with Id = {id} not found"); }

                await _activitiesService.DeleteActivity(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
