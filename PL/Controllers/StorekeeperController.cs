using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/storekeepers")]
    public class StorekeeperController : Controller
    {
        private readonly IBllFactory _bllFactory;
        private readonly IMapper _mapper;
        public StorekeeperController(IBllFactory bllFactory, IMapper mapper)
        {
            _bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
            _mapper = mapper;
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
                var model = _mapper.Map<StorekeeperDto>(storekeeper);
                _bllFactory.StorekeeperBll.Add(storekeeper);
                return Ok(model);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update(List<StorekeeperDto> data)
        {
            try
            {
                var model = _mapper.Map<StorekeeperDto>(data);
                _bllFactory.StorekeeperBll.Update(data);
                return Ok(model);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int storekeeperId)
        {
            try
            {
                _bllFactory.StorekeeperBll.Delete(storekeeperId);
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