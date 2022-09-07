using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhonebookProject1.Core.Dtos.Request;
using PhonebookProject1.Core.Dtos.Response;
using PhonebookProject1.Core.Interfaces;
using PhonebookProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookProject1.Services
{
    public class EntryService : IEntry
    {
        private readonly DataContext _context;
        private readonly ILogger<EntryService> _logger;
        private readonly IMapper _mapper;
        public EntryService(DataContext context, ILogger<EntryService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<(bool, string)> DeleteEntryAsync(int id)
        {
            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return (false, "Entry not found");
            }
            try
            {
                var result = _context.Entries.Remove(entry);
                await _context.SaveChangesAsync();
                return (true, "Entry has been deleted!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public bool EntryExists(int id)
        {
            return (_context.Entries?.Any(e => e.EntryId == id)).GetValueOrDefault();
        }

        public async Task<List<Entry>> GetEntriesAsync()
        {
            try
            {
                var result = await _context.Entries.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<EntryResponse> GetSingleEntry(int id)
        {
            try
            {
                if (id == 0)
                {
                    return null;
                }
                var result = await _context.Entries.FirstOrDefaultAsync(x => x.EntryId == id);
                var response = _mapper.Map<EntryResponse>(result);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool, EntryResponse)> PostEntryAsync(CreateEntry pentry)
        {
            if (_context.Entries == null)
            {
                //  return Problem("Entity set 'DataContext.Entries'  is null.");
            }
            try
            {
                if (pentry == null)
                {
                    return (false, null);
                }
               var createmodel = _mapper.Map<Entry>(pentry);
                _context.Add(createmodel);
                await _context.SaveChangesAsync();
                return (true, new EntryResponse { EntryId = createmodel.EntryId, Mobile = createmodel.Mobile, Name = createmodel.Name, PhoneBookId = createmodel.PhoneBookId });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool, string)> UpdateSingleEntry(UpdateEntry entry, int id)
        {
            try
            {
                if (entry == null || id == 0)
                {
                    return (false, "No item to update");
                }
                var item = await _context.Entries.FirstOrDefaultAsync(z => z.EntryId == id);
                var itemtoupdate = _mapper.Map(entry, item);
                _context.Entries.Update(itemtoupdate);
               await _context.SaveChangesAsync();
                return (true, "Item updated successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
