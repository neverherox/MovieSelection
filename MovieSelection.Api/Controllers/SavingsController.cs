using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSelection.Data.Context;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly MovieSelectionContext _context;
        private readonly IMapper _mapper;

        public SavingsController(MovieSelectionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Savings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saving>>> GetSavings()
        {
            return await _context.Savings.ToListAsync();
        }

        // GET: api/Savings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Saving>> GetSaving(int id)
        {
            var saving = await _context.Savings.FindAsync(id);

            if (saving == null)
            {
                return NotFound();
            }

            return saving;
        }

        // PUT: api/Savings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaving(int id, PutSaving saving)
        {
            if (id != saving.Id)
            {
                return BadRequest();
            }

            var savingEntity = _mapper.Map<Saving>(saving);
            _context.Entry(savingEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavingExists(id))
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

        // POST: api/Savings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<Saving>> PostSaving(PostSaving saving)
        {
            var savingEntity = _mapper.Map<Saving>(saving);
            _context.Savings.Add(savingEntity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SavingExists(savingEntity.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSaving", new { id = savingEntity.Id }, savingEntity);
        }

        // DELETE: api/Savings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaving(int id)
        {
            var saving = await _context.Savings.FindAsync(id);
            if (saving == null)
            {
                return NotFound();
            }

            _context.Savings.Remove(saving);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavingExists(int id)
        {
            return _context.Savings.Any(e => e.Id == id);
        }
    }
}
