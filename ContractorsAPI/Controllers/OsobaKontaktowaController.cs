using AutoMapper;
using ContractorsAPI.Data;
using ContractorsAPI.DTOs;
using ContractorsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Controllers
{
    [Route("api/kontrahenci/{idKontrahent}/oddzialy/{idOddzial}/osobykontaktowe")]
    [ApiController]
    public class OsobaKontaktowaController : ControllerBase
    {
        private readonly IOsobaKontaktowaRepo _repository;
        private readonly IMapper _mapper;

        public OsobaKontaktowaController(IOsobaKontaktowaRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OsobaKontaktowaReadDTO>> GetAllPeople(int idOddzial)
        {
            var peopleItems = _repository.GetAllPeople(idOddzial);
            if (peopleItems == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<OsobaKontaktowaReadDTO>>(peopleItems));
        }
        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<OsobaKontaktowaReadDTO> GetPersonById(int id)
        {
            var peopleItems = _repository.GetPersonById(id);
            if (peopleItems == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OsobaKontaktowaReadDTO>(peopleItems));
        }
        [HttpPost]
        public ActionResult<OsobaKontaktowaReadDTO> CreatePerson(OsobaKontaktowaCreateDTO osobaKontaktowaCreateDTO, int idOddzial)
        {
            var peopleItems = _mapper.Map<OsobaKontaktowa>(osobaKontaktowaCreateDTO);
            peopleItems.OddzialID = idOddzial;
            _repository.CreatePerson(peopleItems);
            _repository.SaveChanges();

            var personReadDto = _mapper.Map<OsobaKontaktowaReadDTO>(peopleItems);
            // CreatedAtRoute(nameof(GetDepartmentById), new { id = departmentReadDto.OddzialID }, departmentReadDto);
            return Ok(personReadDto);

        }
        [HttpPut("{id}")]
        public ActionResult UpdatePerson(int id, OsobaKontaktowaCreateDTO osobaKontaktowaCreateDTO)
        {
            var personModelFromRepo = _repository.GetPersonById(id);
            if (personModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(osobaKontaktowaCreateDTO, personModelFromRepo);
            _repository.UpdatePerson(personModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var personModelFromRepo = _repository.GetPersonById(id);
            if (personModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePerson(personModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
