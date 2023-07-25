using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {


        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct) => await Mediator.Send(new List.Query(), ct);

        [HttpGet("{id}")] //api/activities/guidValue
        public async Task<ActionResult<Activity>> GetActivity(Guid id) => await Mediator.Send(new Details.Query {Id = id});

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity) => Ok(await Mediator.Send(new Create.Command { Activity = activity }));

        [HttpPut("{id}")] //api/activites/guidValue
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id) => Ok(await Mediator.Send(new Delete.Command {Id = id}));

    }
}