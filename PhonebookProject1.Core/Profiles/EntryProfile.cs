using AutoMapper;
using PhonebookProject1.Core.Dtos.Request;
using PhonebookProject1.Core.Dtos.Response;
using PhonebookProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookProject1.Core.Profiles
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<EntryResponse, Entry>();
            CreateMap<Entry, EntryResponse>();
            CreateMap<List<EntryResponse>, List<Entry>>();
            CreateMap<List<Entry>, List<EntryResponse>>();
            CreateMap<CreateEntry, Entry>();
            CreateMap<Entry, CreateEntry>();
            CreateMap<UpdateEntry, Entry>();
            CreateMap<Entry, UpdateEntry>();


        }
    }
}
