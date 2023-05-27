using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Services;

namespace StoreApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : Controller
    {
       private IStoragesRepository _storagesRepository;

        public StoragesController(IStoragesRepository storagesRepository)
        {
            _storagesRepository = storagesRepository;
        }

        //api/storages
        [HttpGet]
        public IActionResult GetStorages()
        {
            var storages = _storagesRepository.GetStorages().ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(storages);
        }
    }
}
