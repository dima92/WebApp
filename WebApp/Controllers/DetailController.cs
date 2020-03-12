using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/details")]
    public class DetailController : Controller
    {

        DetailContext db;

        public DetailController(DetailContext context)
        {
            db = context;

        }
        [HttpGet]
        public IEnumerable<Detail> Get()
        {
            if (!db.Details.Any())
            {
                return db.Details.ToList();
            }

            return null;
        }

        [HttpGet("{id}")]
        public Detail Get(int id)
        {
            Detail detail = db.Details.FirstOrDefault(x => x.Id == id);
            return detail;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Detail detail)
        {
            if (ModelState.IsValid)
            {

                db.Details.Add(detail);
                db.SaveChanges();
                return Ok(detail);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Update(detail);
                db.SaveChanges();
                return Ok(detail);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Detail detail = db.Details.FirstOrDefault(x => x.Id == id);
            if (detail != null)
            {
                detail.DeleteDate = DateTime.Now.ToLocalTime();
                db.Details.Update(detail);
                db.SaveChanges();
            }
            return Ok(detail);
        }

    }
}
