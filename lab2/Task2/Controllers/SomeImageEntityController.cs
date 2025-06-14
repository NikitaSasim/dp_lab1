using Microsoft.AspNetCore.Mvc;

namespace SomeEntityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeImageEntityController : ControllerBase
    {
        private static readonly Dictionary<int, string> _imageMap = new();

        static SomeImageEntityController()
        {
            SomeEntityController.EntityDeleted += OnEntityDeleted;
        }

        private static void OnEntityDeleted(int id)
        {
            _imageMap.Remove(id);
        }

        [HttpGet("image/{id}")]
        public IActionResult GetImage(int id)
        {
            if (_imageMap.TryGetValue(id, out var url))
                return Ok(url);

            return NotFound("Image not set");
        }

        [HttpPost("image/{id}")]
        public async Task<IActionResult> SetImage(int id, [FromBody] string imageUrl)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{Request.Scheme}://{Request.Host}");

            var response = await httpClient.GetAsync($"/api/SomeEntity/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound($"SomeEntity with id {id} does not exist");

            _imageMap[id] = imageUrl;
            return Ok();
        }

        [HttpGet("filter")]
        public IActionResult GetEntitiesByFilter([FromQuery] string? status, [FromQuery] string? name)
        {
            var baseEntitiesResult = new SomeEntityController().GetByFilter(status, name, null) as OkObjectResult;

            if (baseEntitiesResult?.Value is not List<SomeEntity> baseEntities)
                return NotFound("No base entities found");

            var result = baseEntities.Select(e => new SomeImageEntity
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Status = e.Status,
                ImageUrl = _imageMap.ContainsKey(e.Id) ? _imageMap[e.Id] : "N/A"
            }).ToList();

            return Ok(result);
        }
    }
}
