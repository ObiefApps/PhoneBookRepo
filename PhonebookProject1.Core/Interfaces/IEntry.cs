using PhonebookProject1.Core.Dtos.Request;
using PhonebookProject1.Core.Dtos.Response;
using PhonebookProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace PhonebookProject1.Core.Interfaces
{
    public interface IEntry
    {
        Task<List<Entry>> GetEntriesAsync();
        Task<EntryResponse> GetSingleEntry(int id);
        Task<(bool, EntryResponse)> PostEntryAsync(CreateEntry entry);
        Task<(bool, string)> UpdateSingleEntry(UpdateEntry entry, int id);
        Task<(bool, string)> DeleteEntryAsync(int id);
        bool EntryExists(int id);

    }
}
