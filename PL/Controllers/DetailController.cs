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
    public class DetailsController : ControllerBase
    {
        private IBllFactory bllFactory;
        public DetailsController(IBllFactory bllFactory)
        {
            this.bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<DetailDto> result = new List<DetailDto>();
                List<Detail> allDetails = bllFactory.DetailBll.GetAll().ToList();
                foreach (var detail in allDetails)
                {
                    result.Add(new DetailDto
                    {
                        Id = detail.Id,
                        Created = detail.Created,
                        DeleteDate = detail.DeleteDate,
                        Name = detail.Name,
                        NomenclatureCode = detail.NomenclatureCode,
                        Quantity = detail.Quantity,
                        SpecAccount = detail.SpecAccount,
                        NameStorekeeper = detail.Storekeeper.Name
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
    }
}