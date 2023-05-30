using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.Migrations;
using StoreApiProject.Models;
using StoreApiProject.Services;

namespace StoreApiProject.Controllers
{
  

        [Route("api/[controller]")]
        [ApiController]
        public class StateOfStoragesController : Controller
        {
            private IStateOfStoragesRepository _stateOfStoragesRepository;
            private AppDbContext _dbContext;

            public StateOfStoragesController(IStateOfStoragesRepository stateOfStoragesRepository, AppDbContext dbContext)
            {
                _stateOfStoragesRepository = stateOfStoragesRepository;
                _dbContext = dbContext;
        }

            //api/stateOfStorages
            [HttpGet]
            public IActionResult GetStateOfStorages()
            {
                var stateOfStorages = _stateOfStoragesRepository.GetStateOfStorages().ToList();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(stateOfStorages);
            }
        /// POST: api/stateOfStorage
        /// 
        [HttpPost]
        public IActionResult AddStateOfStorage([FromBody] StateOfStorageRequestModel model)
        {
            var newStateOfStorage = new StateOfStorage
            {
                ProductId = model.ProductId,
                StorageId = model.StorageId,
                Quantity = model.Quantity
            };

            _dbContext.Add(newStateOfStorage);
            _dbContext.SaveChanges();

            return Ok();
        }

        /// DELETE: api/stateOfStorage/delete/{stateOfStorageId}
        [HttpDelete("delete/{stateOfStorageId}")]
        public IActionResult DeleteStateOfStorage(int stateOfStorageId)
        {
            _stateOfStoragesRepository.DeleteStateOfStorage(stateOfStorageId);
            return NoContent();
        }

    }
    public class StateOfStorageRequestModel
    {
        public int ProductId { get; set; }
        public int StorageId { get; set; }
        public int Quantity { get; set; }
    }
}
