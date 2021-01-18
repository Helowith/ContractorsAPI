using AutoMapper;
using ContractorsAPI.DTOs;
using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Profiles
{
    public class OsobaKontaktowaProfile : Profile
    {
        public OsobaKontaktowaProfile()
        {
            CreateMap<OsobaKontaktowaCreateDTO, OsobaKontaktowa>();
            CreateMap<OsobaKontaktowa, OsobaKontaktowaReadDTO>();
        }
    }
}
