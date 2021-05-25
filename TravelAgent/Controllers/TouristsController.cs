using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgent.DataAccess;
using TravelAgent.Models;

namespace TravelAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristsController : ControllerBase
    {
        private readonly TravelAgentContext _context;

        public TouristsController(TravelAgentContext context)
        {
            _context = context;
        }

        // GET: api/Tourists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tourist>>> GetTourist()
        {
            return await _context.Tourist.ToListAsync();
        }

        // GET: api/Tourists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tourist>> GetTourist(long id)
        {
            var tourist = await _context.Tourist.FindAsync(id);

            if (tourist == null)
            {
                return NotFound();
            }

            return tourist;
        }

        // GET: api/Tourists/5
        [HttpGet("{email}")]
        public async Task<ActionResult<Tourist>> GetTouristByEmail(string email)
        {
            var tourist = await _context.Tourist.FirstOrDefaultAsync(x=>x.Email==email);

            if (tourist == null)
            {
                return NotFound();
            }

            return tourist;
            
        }
        // PUT: api/Tourists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourist(long id, Tourist tourist)
        {
            if (id != tourist.Id)
            {
                return BadRequest();
            }

            _context.Entry(tourist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristExists(id))
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

        // POST: api/Tourists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tourist>> PostTourist(Tourist tourist)
        {

            var isTouristExist = await _context.Tourist.AnyAsync(x => x.Email == tourist.Email);

            if (isTouristExist)
            {
                return StatusCode(StatusCodes.Status409Conflict, $"Tourist with email address {tourist.Email} is already exists.");
            }

            _context.Tourist.Add(tourist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourist", new { id = tourist.Id }, tourist);
        }

        // DELETE: api/Tourists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourist(long id)
        {
            var tourist = await _context.Tourist.FindAsync(id);
            if (tourist == null)
            {
                return NotFound();
            }

            _context.Tourist.Remove(tourist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TouristExists(long id)
        {
            return _context.Tourist.Any(e => e.Id == id);
        }
    }
}
