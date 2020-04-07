using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using BLL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class DetailController : Controller
    {
        private readonly IBllFactory _bllFactory;
        private readonly IMapper _mapper;

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
            _bllFactory.DetailBll.Delete(id);
            return Ok();
        }
    }
}