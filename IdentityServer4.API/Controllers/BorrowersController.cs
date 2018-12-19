using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServer4.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowersController : ControllerBase
    {
        private readonly LoanContext _context;

        public BorrowersController(LoanContext context)
        {
            _context = context;
        }

        // GET: api/Borrowers
        [HttpGet]
        public IEnumerable<Borrower> GetBorrower()
        {
            return _context.Borrower;
        }

        // GET: api/Borrowers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBorrower([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrower = await _context.Borrower.FindAsync(id);

            if (borrower == null)
            {
                return NotFound();
            }

            return Ok(borrower);
        }

        // PUT: api/Borrowers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrower([FromRoute] long id, [FromBody] Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != borrower.Id)
            {
                return BadRequest();
            }

            _context.Entry(borrower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerExists(id))
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

        // POST: api/Borrowers
        [HttpPost]
        public async Task<IActionResult> PostBorrower([FromBody] Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Borrower.Add(borrower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrower", new { id = borrower.Id }, borrower);
        }

        // DELETE: api/Borrowers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrower([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrower = await _context.Borrower.FindAsync(id);
            if (borrower == null)
            {
                return NotFound();
            }

            _context.Borrower.Remove(borrower);
            await _context.SaveChangesAsync();

            return Ok(borrower);
        }

        private bool BorrowerExists(long id)
        {
            return _context.Borrower.Any(e => e.Id == id);
        }
    }
}