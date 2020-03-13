using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorekeeperController : ControllerBase
    {
        private IBllFactory bllFactory;
        public StorekeeperController(IBllFactory bllFactory)
        {
            this.bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<StorekeeperDto> result = new List<StorekeeperDto>();
                List<Storekeeper> allStorekeepers = bllFactory.StorekeeperBll.GetAll().ToList();
                foreach (var storekeeper in allStorekeepers)
                {
                    result.Add(new StorekeeperDto
                    {
                        Id = storekeeper.Id,
                        Name = storekeeper.Name,
                        SumKolDetail = storekeeper.SumKolDetail
                    });
                }

                result = result.ToList();
                return Ok(result);
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
            var result = bllFactory.StorekeeperBll.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(StorekeeperDto storekeeper)
        {
            bllFactory.StorekeeperBll.Add(storekeeper);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int storekeeperId)
        {
           // Detail detail = bllFactory.DetailBll.Where(p => p.Quantity > 0).FirstOrDefault(x => x.StorekeeperId == Storekeeper.Id);

            bllFactory.StorekeeperBll.Delete(storekeeperId);
            return Ok();
        }
    }
}