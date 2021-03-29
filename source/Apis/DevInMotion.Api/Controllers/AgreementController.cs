using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevInMotion.Api.Data;
using DevInMotionApi.Models;

namespace DevInMotion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        private readonly DevInMotionApiContext _context;

        public AgreementController(DevInMotionApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agreement>>> GetAgreement()
        {
            return await _context.Agreement.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agreement>> GetAgreement(int id)
        {
            var Agreement = await _context.Agreement.FindAsync(id);

            if (Agreement == null)
            {
                return NotFound();
            }

            return Agreement;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgreement(int id, Agreement Agreement)
        {
            if (id != Agreement.Id)
            {
                return BadRequest();
            }

            _context.Entry(Agreement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgreementExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Agreement>> PostAgreement(Agreement Agreement)
        {
            _context.Agreement.Add(Agreement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgreement", new { id = Agreement.Id }, Agreement);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Agreement>> DeleteAgreement(int id)
        {
            var Agreement = await _context.Agreement.FindAsync(id);
            if (Agreement == null)
            {
                return NotFound();
            }

            _context.Agreement.Remove(Agreement);
            await _context.SaveChangesAsync();

            return Agreement;
        }

        private bool AgreementExists(int id)
        {
            return _context.Agreement.Any(e => e.Id == id);
        }
    }
}
