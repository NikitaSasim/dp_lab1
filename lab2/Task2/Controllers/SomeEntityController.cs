using Microsoft.AspNetCore.Mvc;

namespace SomeEntityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeEntityController : ControllerBase
    {
        private static List<SomeEntity> _entities = new();
        public static event Action<int>? EntityDeleted;

        [HttpPost]
        public IActionResult Create([FromBody] SomeEntity entity)
        {
            entity.Id = _entities.Count > 0 ? _entities.Max(e => e.Id) + 1 : 1;
            _entities.Add(entity);
            return CreatedAtAction(nameof(GetOne), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SomeEntity updated)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();

            entity.Name = updated.Name;
            entity.Description = updated.Description;
            entity.Status = updated.Status;

            return Ok(entity);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            return entity != null ? Ok(entity) : NotFound();
        }

        [HttpGet]
        public IActionResult GetMany()
        {
            return Ok(_entities);
        }

        [HttpGet("filter")]
        public IActionResult GetByFilter([FromQuery] string? status, [FromQuery] string? name, [FromQuery] string? description)
        {
            var query = _entities.AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(e => e.Status == status);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => e.Name.Contains(name));

            if (!string.IsNullOrEmpty(description))
                query = query.Where(e => e.Description.Contains(description));

            return Ok(query.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();
            _entities.Remove(entity);
            EntityDeleted?.Invoke(id);

            return NoContent();
        }

        [HttpPost("delete-many")]
        public IActionResult DeleteMany([FromBody] List<int> ids)
        {
            _entities.RemoveAll(e => ids.Contains(e.Id));
            return NoContent();
        }

        [HttpGet("{id}/print")]
        public IActionResult Print(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            return entity != null
                ? Ok($"Entity: {entity.Id} | {entity.Name} | {entity.Description} | {entity.Status}")
                : NotFound();
        }

        [HttpGet("print-many")]
        public IActionResult PrintMany()
        {
            var result = _entities.Select(e => $"{e.Id}: {e.Name} - {e.Description} [{e.Status}]").ToList();
            return Ok(result);
        }

        [HttpPost("{id}/status")]
        public IActionResult SetStatus(int id, [FromBody] string status)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();
            entity.Status = status;
            return Ok(entity);
        }

        [HttpPost("{id}/deactivate")]
        public IActionResult Deactivate(int id) => SetStatus(id, "Inactive");

        [HttpPost("{id}/activate")]
        public IActionResult Activate(int id) => SetStatus(id, "Active");
    }
}
