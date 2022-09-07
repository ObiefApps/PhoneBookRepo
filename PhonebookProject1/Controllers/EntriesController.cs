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
    [ApiController]
    [Route("api/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly IEntry _entry;

        public EntriesController(IEntry entry)
        {
            _entry = entry;
        }

        // GET: api/Entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetEntries()
        {
          if (_entry.GetEntriesAsync == null)
          {
              return NoContent();
          }
          var result = await _entry.GetEntriesAsync();  
            return Ok(result);
        }

        // GET: api/Entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(int id)
        {
            var result = await _entry.GetSingleEntry(id);
            return Ok(result);
        }

        // PUT: api/Entries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry(int id, UpdateEntry entry)
        {
            var result = await _entry.UpdateSingleEntry(entry, id);
            if (result.Item1 != true)
            {
                return BadRequest(result.Item2);
            }
            return NoContent();
        }

        // POST: api/Entries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(CreateEntry pentry)
        {
           
                if (pentry == null)
                {
                    return NoContent();
                }
                var result = await _entry.PostEntryAsync(pentry);
                if (result.Item1 == false)
                {
                    return BadRequest();
                }
            return CreatedAtAction("GetEntry", new { id = result.Item2.EntryId }, result.Item2);

        }
        // DELETE: api/Entries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(int id)
        {
           var result = await _entry.DeleteEntryAsync(id);
            if (result.Item1 == false)
            {
                return BadRequest(result.Item2);
            }
            return NoContent();
        }
    }
}
