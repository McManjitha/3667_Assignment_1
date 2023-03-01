using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using votingApp2.Models;

namespace votingApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VottersController : ControllerBase
    {
        private readonly DataContext _context;

        public VottersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Votters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Votter>>> GetVotters()
        {
            return await _context.Votters.ToListAsync();
        }

        // GET: api/Votters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Votter>> GetVotter(int id)
        {
            var votter = await _context.Votters.FindAsync(id);

            if (votter == null)
            {
                return NotFound();
            }

            return votter;
        }

        // PUT: api/Votters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVotter(int id, Votter votter)
        {
            if (id != votter.user_Id)
            {
                return BadRequest();
            }

            _context.Entry(votter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Votters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Votter>> PostVotter(Votter votter)
        {
            _context.Votters.Add(votter);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetVotter", new { id = votter.user_Id }, votter);
            return CreatedAtAction(nameof(GetVotter), new { id = votter.user_Id }, votter);
        }

        // DELETE: api/Votters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVotter(int id)
        {
            var votter = await _context.Votters.FindAsync(id);
            if (votter == null)
            {
                return NotFound();
            }

            _context.Votters.Remove(votter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VotterExists(int id)
        {
            return _context.Votters.Any(e => e.user_Id == id);
        }
    }
}
