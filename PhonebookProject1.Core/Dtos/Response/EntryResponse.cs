using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookProject1.Core.Dtos.Response
{
    public class EntryResponse
    {
        public int EntryId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int PhoneBookId { get; set; }
    }
}
