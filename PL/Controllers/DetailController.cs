using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using BLL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class DetailController : Controller
    {
        private readonly IBllFactory _bllFactory = new BllFactory();
        private IMapper _mapper;

        public DetailController(IBllFactory bllFactory, IMapper mapper)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
            _mapper = mapper;
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
                var model = _mapper.Map<DetailDto>(detail);
                _bllFactory.DetailBll.Add(model);
                return Ok(model);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int detailId)
        {
            _bllFactory.DetailBll.Delete(detailId);
            return Ok();
        }
    }
}