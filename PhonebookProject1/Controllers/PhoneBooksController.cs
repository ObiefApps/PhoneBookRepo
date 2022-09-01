using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonebookProject1.Models;

namespace PhonebookProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private readonly DataContext _context;

        public PhoneBooksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PhoneBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneBook>>> GetPhones()
        {
          if (_context.Phones == null)
          {
              return NotFound();
          }
            return await _context.Phones.ToListAsync();
        }

        // GET: api/PhoneBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneBook>> GetPhoneBook(int id)
        {
          if (_context.Phones == null)
          {
              return NotFound();
          }
            var phoneBook = await _context.Phones.FindAsync(id);

            if (phoneBook == null)
            {
                return NotFound();
            }
            return phoneBook;
        }

        // PUT: api/PhoneBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneBook(int id, PhoneBook phoneBook)
        {
            if (id != phoneBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneBookExists(id))
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

        // POST: api/PhoneBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneBook>> PostPhoneBook(PhoneBook phoneBook)
        {
          if (_context.Phones == null)
          {
              return Problem("Entity set 'DataContext.Phones'  is null.");
          }
            _context.Phones.Add(phoneBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneBook", new { id = phoneBook.Id }, phoneBook);
        }

        // DELETE: api/PhoneBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneBook(int id)
        {
            if (_context.Phones == null)
            {
                return NotFound();
            }
            var phoneBook = await _context.Phones.FindAsync(id);
            if (phoneBook == null)
            {
                return NotFound();
            }

            _context.Phones.Remove(phoneBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneBookExists(int id)
        {
            return (_context.Phones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
