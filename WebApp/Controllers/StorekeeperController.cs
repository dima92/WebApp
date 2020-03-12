using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/storekeepers")]
    public class StorekeeperController : Controller
    {

        DetailContext db;
        public StorekeeperController(DetailContext context)
        {
            db = context;

        }

        [HttpGet]
        public IEnumerable<Storekeeper> Get()
        {
            if (db.Storekeepers.Any())
            {
                return db.Storekeepers.ToList();
            }
            else
                return null;

        }

        [HttpGet("{id}")]
        public Storekeeper Get(int id)
        {
            Storekeeper Storekeeper = db.Storekeepers.FirstOrDefault(x => x.Id == id);
            return Storekeeper;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Storekeeper Storekeeper)
        {
            if (ModelState.IsValid)
            {
                db.Storekeepers.Add(Storekeeper);
                db.SaveChanges();
                return Ok(Storekeeper);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Storekeeper Storekeeper)
        {
            if (ModelState.IsValid)
            {
                db.Update(Storekeeper);
                db.SaveChanges();
                return Ok(Storekeeper);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Storekeeper Storekeeper = db.Storekeepers.FirstOrDefault(x => x.Id == id);

            if (Storekeeper != null)
            {
                Detail detail = db.Details.Where(p => p.Quantity > 0).FirstOrDefault(x => x.StorekeeperId == Storekeeper.Id);

                if (detail != null)
                {
                    return BadRequest("Нельзя удалить кладовщика, за которым числятся детали");
                }
                else
                {
                    db.Storekeepers.Remove(Storekeeper);
                    db.SaveChanges();
                }

            }
            return Ok(Storekeeper);
        }
    }
}
