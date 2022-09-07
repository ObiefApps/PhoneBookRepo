using AutoMapper;
using Microsoft.Extensions.Logging;
using PhonebookProject1.Core.Dtos.Request;
using PhonebookProject1.Core.Dtos.Response;
using PhonebookProject1.Core.Interfaces;
using PhonebookProject1.Models;

namespace PhonebookProject1.Services
{
    public class PhonebookService : IPhoneBook
    {
        private readonly DataContext _context;
        private readonly ILogger<PhonebookService> _logger;
        private readonly IMapper _mapper;
        public PhonebookService(DataContext context, IMapper mapper, ILogger<PhonebookService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<(bool, string)> DeleteEntryAsync(int id)
        {
            var entry = await _context.Phones.FindAsync(id);
            if (entry == null)
            {
                return (false, "Entry not found");
            }
            try
            {
                var result = _context.Phones.Remove(entry);
                await _context.SaveChangesAsync();
                return (true, "Entry has been deleted!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<List<PhonebookResponse>> GetPhonebooksAsync()
        {
            try
            {
                var result = _context.Phones.AsQueryable();
                var response = _mapper.Map<IEnumerable<PhonebookResponse>>(result);
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PhonebookResponse> GetSingleEntry(int id)
        {
            try
            {
                if (id == 0)
                {
                    return null;
                }
                var result = await _context.Phones.FindAsync(id);
                var response = _mapper.Map<PhonebookResponse>(result);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool PhonebookExists(int id)
        {
            return (_context.Phones?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<(bool, PhonebookResponse)> PostEntryAsync(CreatePhonebook phone)
        {
             if (_context.Phones == null)
            {
                //  return Problem("Entity set 'DataContext.Entries'  is null.");
            }
            try
            {
                if (phone == null)
                {
                    return (false, null);
                }
                var createmodel = _mapper.Map<PhoneBook>(phone);
                _context.Add(createmodel);
                await _context.SaveChangesAsync();
                return (true, new PhonebookResponse { Id = createmodel.Id, Name = createmodel.Name, Entries = (IList<EntryResponse>)createmodel.Entries });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool, string)> UpdateSingleEntry(UpdatePhonebook entry, int id)
        {
            try
            {
                if (entry == null || id == 0)
                {
                    return (false, "No item to update");
                }
                var item = await _context.Phones.FindAsync(id);
                var itemtoupdate = _mapper.Map(entry, item);
                _context.Phones.Update(itemtoupdate);
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