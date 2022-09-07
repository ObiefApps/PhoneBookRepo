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
    public class PhonebookProfile : Profile
    {
        public PhonebookProfile()
        {
            CreateMap<PhonebookResponse, PhoneBook>();
            CreateMap<PhoneBook, PhonebookResponse>();
            CreateMap<PhoneBook, CreatePhonebook>();
            CreateMap<CreatePhonebook, PhoneBook>();
            CreateMap<UpdatePhonebook, PhoneBook>();
            CreateMap<PhoneBook, UpdatePhonebook>();

        }
    }
}
