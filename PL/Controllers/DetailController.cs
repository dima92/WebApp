using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Repository;
using DAL.EF;
using DAL.Entities;

namespace PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetailController : ControllerBase
    {
        private readonly IBllFactory _bllFactory = new BllFactory();

        private DetailContext db;

        public DetailController(DetailContext context)
        {
            db = context;
            //if (!db.Details.Any())
            //{
            //    db.Details.Add(new Detail { Name = "iPhone X", Company = "Apple", Price = 79900 });
            //    db.Details.Add(new Detail { Name = "Galaxy S8", Company = "Samsung", Price = 49900 });
            //    db.Details.Add(new Detail { Name = "Pixel 2", Company = "Google", Price = 52900 });
            //    db.SaveChanges();
            //}
        }
        //public DetailController(IBllFactory bllFactory)
        //{
        //    this.bllFactory = bllFactory ?? throw new ArgumentNullException(nameof(bllFactory));
        //}

        [HttpGet]
        public IActionResult GetAll()
        {

            //try
            //{
            //    List<DetailDto> result = new List<DetailDto>();
               // List<Detail> allDetails = _bllFactory.DetailBll.GetAll().ToList();
                var x = db.Details.ToList();
            //    foreach (var detail in allDetails)
            //    {
            //        result.Add(new DetailDto
            //        {
            //            Id = detail.Id,
            //            Created = detail.Created,
            //            DeleteDate = detail.DeleteDate,
            //            Name = detail.Name,
            //            NomenclatureCode = detail.NomenclatureCode,
            //            Quantity = detail.Quantity,
            //            SpecAccount = detail.SpecAccount,
            //            NameStorekeeper = detail.Storekeeper.Name
            //        });
            //    }

            //    result = result.ToList();
                return Ok();
            //}
            //catch (ValidationException ex)
            //{
            //    ModelState.AddModelError("error", ex.Message);
            //    return BadRequest(ModelState);
            //}
        }
    }
}