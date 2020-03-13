using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorekeeperController : ControllerBase
    {
        private readonly IBllFactory _bllFactory;
        public StorekeeperController(IBllFactory bllFactory)
        {
            this._bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allStorekeepers = _bllFactory.StorekeeperBll.GetAll();
                return Ok(allStorekeepers);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public IActionResult GetStorekeepers(int id)
        {
            var result = _bllFactory.StorekeeperBll.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(StorekeeperDto storekeeper)
        {
            _bllFactory.StorekeeperBll.Add(storekeeper);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int storekeeperId)
        {
            //.Where(p => p.Quantity > 0).FirstOrDefault(x => x.StorekeeperId == Storekeeper.Id);

            _bllFactory.StorekeeperBll.Delete(storekeeperId);
            return Ok();
        }
    }
}