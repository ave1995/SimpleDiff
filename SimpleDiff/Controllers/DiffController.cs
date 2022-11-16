using Microsoft.AspNetCore.Mvc;
using SimpleDiff.Diff;
using SimpleDiff.Models;

namespace SimpleDiff.Controllers
{
    [ApiController]
    [Route("v1/diff/{id:int?}")]
    [Produces("application/json")]
    public sealed class DiffController : ControllerBase
    {
        private DiffItemManager DiffItemManager { get; }

        public DiffController(DiffItemManager diffItemManager)
        {
            DiffItemManager = diffItemManager;
        }

        [HttpPost]
        [Route("left")]
        public async Task<IActionResult> Left(int id, [FromBody] DiffPostModel item)
        {
            return await GetResultForCreate(() => DiffItemManager.CreateItemAsync(id, DiffType.Left, item.Input));
        }

        [HttpPost]
        [Route("right")]
        public async Task<IActionResult> Right(int id, [FromBody] DiffPostModel item)
        {
            return await GetResultForCreate(() => DiffItemManager.CreateItemAsync(id, DiffType.Right, item.Input));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Diff(int id)
        {
            var result = await DiffItemManager.GetResultForItemAsync(id);
            if (result is null) return NotFound();
           
            return Ok(new DiffGetModel { Result = result});
        }
        
        private async Task<IActionResult> GetResultForCreate(Func<Task<Result>> callback)
        {
            var result = await callback();
            if (result.Success) return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
        }
    }
}
