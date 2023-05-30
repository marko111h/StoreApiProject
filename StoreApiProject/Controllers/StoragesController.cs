using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.Models;
using StoreApiProject.Services;

namespace StoreApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : Controller
    {
       private IStoragesRepository _storagesRepository;
        private AppDbContext _dbContext;

        public StoragesController(IStoragesRepository storagesRepository, AppDbContext dbContext)
        {
            _storagesRepository = storagesRepository;
            _dbContext = dbContext;
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
        /// DELETE: api/storages/delete/{storageIdDelete}
        [HttpDelete("delete/{storageId}")]
        public IActionResult DeleteStorage(int storageId)
        {
            _storagesRepository.DeleteStorage(storageId);
            return NoContent();
        }

        /// POST: api/storages
        /// 
        [HttpPost]
        public IActionResult AddStorage([FromBody] StorageRequestModel model)
        {
            var newStorage = new Storage
            {
                StorageName = model.Name,
                KindOfStorage = model.KOS
            };

            _dbContext.Add(newStorage);
            _dbContext.SaveChanges();

            return Ok();
        }

    }

    public class StorageRequestModel
    {
        public string Name { get; set; }
        public string KOS { get; set; }
    }
}
