using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonebookProject1.Core.Dtos.Request;
using PhonebookProject1.Core.Interfaces;
using PhonebookProject1.Models;

namespace PhonebookProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private readonly IPhoneBook _phone;

        public PhoneBooksController(IPhoneBook phone)
        {
            _phone = phone;
        }

        // GET: api/PhoneBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneBook>>> GetPhones()
        {
            if (_phone.GetPhonebooksAsync == null)
            {
                return NoContent();
            }
            var result = await _phone.GetPhonebooksAsync();
            return Ok(result);
        }

        // GET: api/PhoneBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneBook>> GetPhoneBook(int id)
        {
            var phoneBook = await _phone.GetSingleEntry(id);
            if (phoneBook == null)
            {
                return NotFound();
            }
            return Ok(phoneBook);
        }

        // PUT: api/PhoneBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneBook(int id, UpdatePhonebook phoneBook)
        {
            var result = await _phone.UpdateSingleEntry(phoneBook, id);
            if (result.Item1 != true)
            {
                return BadRequest(result.Item2);
            }
            return NoContent();
        }

        // POST: api/PhoneBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneBook>> PostPhoneBook(CreatePhonebook phoneBook)
        {
            if (phoneBook == null)
            {
                return NoContent();
            }
            var result = await _phone.PostEntryAsync(phoneBook);
            if (result.Item1 == false)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetPhoneBook", new { id = result.Item2.Id }, result.Item2);
        }

        // DELETE: api/PhoneBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneBook(int id)
        {
            var result = await _phone.DeleteEntryAsync(id);
            if (result.Item1 == false)
            {
                return BadRequest(result.Item2);
            }
            return NoContent();
        }
    }
}
