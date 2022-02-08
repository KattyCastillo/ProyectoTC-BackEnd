using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd;
using BackEnd.Models;

namespace BackEnd.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class TrajetaCreditoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TrajetaCreditoController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TrajetaCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrajetaCredito>>> GetTarjetaCreditos()
        {
            return await _context.TarjetaCreditos.ToListAsync();
        }

        // GET: api/TrajetaCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrajetaCredito>> GetTrajetaCredito(int id)
        {
            var trajetaCredito = await _context.TarjetaCreditos.FindAsync(id);

            if (trajetaCredito == null)
            {
                return NotFound();
            }

            return trajetaCredito;
        }

        // PUT: api/TrajetaCredito/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrajetaCredito(int id, TrajetaCredito trajetaCredito)
        {
            if (id != trajetaCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(trajetaCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrajetaCreditoExists(id))
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

        // POST: api/TrajetaCredito
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TrajetaCredito>> PostTrajetaCredito(TrajetaCredito trajetaCredito)
        {
            _context.TarjetaCreditos.Add(trajetaCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrajetaCredito", new { id = trajetaCredito.Id }, trajetaCredito);
        
        }

        // DELETE: api/TrajetaCredito/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrajetaCredito>> DeleteTrajetaCredito(int id)
        {
            var trajetaCredito = await _context.TarjetaCreditos.FindAsync(id);
            if (trajetaCredito == null)
            {
                return NotFound();
            }

            _context.TarjetaCreditos.Remove(trajetaCredito);
            await _context.SaveChangesAsync();

            return trajetaCredito;
        }

        private bool TrajetaCreditoExists(int id)
        {
            return _context.TarjetaCreditos.Any(e => e.Id == id);
        }
    }
}
