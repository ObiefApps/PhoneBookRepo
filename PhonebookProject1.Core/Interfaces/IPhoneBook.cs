using PhonebookProject1.Core.Dtos.Request;
using PhonebookProject1.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookProject1.Core.Interfaces
{
    public interface IPhoneBook
    {
        Task<List<PhonebookResponse>> GetPhonebooksAsync();
        Task<PhonebookResponse> GetSingleEntry(int id);
        Task<(bool, PhonebookResponse)> PostEntryAsync(CreatePhonebook entry);
        Task<(bool, string)> UpdateSingleEntry(UpdatePhonebook entry, int id);
        Task<(bool, string)> DeleteEntryAsync(int id);
        bool PhonebookExists(int id);
    }
}
