using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookProject1.Core.Dtos.Response
{
    public class PhonebookResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<EntryResponse> Entries { get; set; }
    }
}
