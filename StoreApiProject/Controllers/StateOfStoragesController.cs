using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Services;

namespace StoreApiProject.Controllers
{
  

        [Route("api/[controller]")]
        [ApiController]
        public class StateOfStoragesController : Controller
        {
            private IStateOfStoragesRepository _stateOfStoragesRepository;

            public StateOfStoragesController(IStateOfStoragesRepository stateOfStoragesRepository)
            {
                _stateOfStoragesRepository = stateOfStoragesRepository;
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
        }
    }
