using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        // db
        private AspModel db;

        public SportsController(AspModel db)
        {
            this.db = db;
        }

        // GET: api/sports
        [HttpGet]
        public IEnumerable<Sport> Get()
        {
            return db.Sports.OrderBy(a => a.Boys).ToList();
        }

        // GET: api/sports/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
           Sport sport = db.Sports.Find(id);

            if (sport == null)
            {
                return NotFound();
            }
            return Ok(sport);
            
        }

        // POST: api/sports
        [HttpPost]
        public ActionResult Post([FromBody] Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sports.Add(sport);
            db.SaveChanges();
            return CreatedAtAction("Post", sport);
        }

        // PUT: api/sports/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(sport).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/sports/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Sport sport = db.Sports.Find(id);

            if (sport == null)
            {
                return NotFound();
            }

            db.Sports.Remove(sport);
            db.SaveChanges();
            return Ok();
        }
    }
}
