using AutoMapper;
using ContractorsAPI.DTOs;
using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Profiles
{
    public class OddzialProfile : Profile
    {
        public OddzialProfile()
        {
            CreateMap<OddzialCreateDTO, Oddzial>();
            CreateMap<OddzialUpdateDTO, Oddzial>();
            CreateMap<Oddzial, OddzialReadDTO>();
        }
            
    }
}
