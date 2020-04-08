using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class DetailController : Controller
    {
        private readonly IBllFactory _bllFactory;

        public DetailController(IBllFactory bllFactory)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allDetails = _bllFactory.DetailBll.GetAll();
                return Ok(allDetails);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            var result = _bllFactory.DetailBll.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(DetailDto detail)
        {
            try
            {
                _bllFactory.DetailBll.Add(detail);
                return Ok();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update(DetailDto data)
        {
            try
            {
                _bllFactory.DetailBll.Update(data);
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
                _bllFactory.DetailBll.Delete(id);
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