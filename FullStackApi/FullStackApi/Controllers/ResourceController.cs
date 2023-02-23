using FullStackApi.Context;
using FullStackApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ProjectContext db;

        public ResourceController(ProjectContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<Resource>> Get()
        {
            List<Resource> resources = db.Recourses.ToList();

            return Ok(resources);
        }

        [HttpPost]
        public ActionResult<Resource> Post([FromBody] Resource resource)
        {
            db.Recourses.Add(resource);
            db.SaveChanges();

            return Ok(resource);
        }
    }
}
