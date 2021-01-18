using AutoMapper;
using ContractorsAPI.DTOs;
using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Profiles
{
    public class KontrahenciProfile : Profile
    {
        public KontrahenciProfile()
        {
            CreateMap<KontrahentCreateDTO, Kontrahent>();
            CreateMap<KontrahentUpdateDTO, Kontrahent>();
            CreateMap<Kontrahent, KontrahentReadDTO>();
        }
    }
}
