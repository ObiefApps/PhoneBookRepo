using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookProject1.Core.Dtos.Request
{
    public class CreatePhonebook
    {
        public string Name { get; set; }
        public IList<CreateEntry> Entries { get; set; }
    }
}
