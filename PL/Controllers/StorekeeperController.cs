using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/storekeepers")]
    public class StorekeeperController : Controller
    {
        private readonly IBllFactory _bllFactory;
        public StorekeeperController(IBllFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
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

        [HttpGet("{id}")]
        public IActionResult GetStorekeepers(int id)
        {
            var result = _bllFactory.StorekeeperBll.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(StorekeeperDto storekeeper)
        {
            try
            {
                _bllFactory.StorekeeperBll.Add(storekeeper);
                return Ok();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update(StorekeeperDto data)
        {
            try
            {
                _bllFactory.StorekeeperBll.Update(data);
                return Ok();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bllFactory.StorekeeperBll.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("warn", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}