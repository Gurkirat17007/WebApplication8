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
    public class TeamsController : ControllerBase
    {
        // db
        private AspModel db;

        public TeamsController(AspModel db)
        {
            this.db = db;
        }

        // GET: api/teams
        
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return db.Teams.OrderBy(a => a.Boys).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
         Team team = db.Teams.Find(id);

            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // POST: api/teams
        [HttpPost]
        public ActionResult Post([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);
            db.SaveChanges();
            return CreatedAtAction("Post", team);
        }

        // PUT: api/teams/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/teams/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Team team = db.Teams.Find(id);

            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();
            return Ok();
        }
    }
}
