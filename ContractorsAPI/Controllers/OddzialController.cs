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
    [Route("api/kontrahenci/{idKontrahent}/oddzialy")]
    [ApiController]
    public class OddzialController : ControllerBase
    {
        private readonly IOddzialRepo _repository;
        private readonly IMapper _mapper;

        public OddzialController(IOddzialRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OddzialReadDTO>> GetAllDepartments(int idKontrahent)
        {
            var departmentsItems = _repository.GetAllDepartments(idKontrahent);
            if (departmentsItems == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<OddzialReadDTO>>(departmentsItems));
        }
        [HttpGet("{id}", Name = "GetDepartmentById")]
        public ActionResult<OddzialReadDTO> GetDepartmentById(int id)
        {
            var departmentsItems = _repository.GetDepartmentById(id);
            if (departmentsItems == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OddzialReadDTO>(departmentsItems));
        }
        [HttpPost]
        public ActionResult<OddzialReadDTO> CreateDepartment(OddzialCreateDTO oddzialCreateDTO, int idKontrahent)
        {
            var departmentItems = _mapper.Map<Oddzial>(oddzialCreateDTO);
            departmentItems.KontrahentID = idKontrahent;
            _repository.CreateDepartment(departmentItems);
            _repository.SaveChanges();

            var departmentReadDto = _mapper.Map<OddzialReadDTO>(departmentItems);
            // CreatedAtRoute(nameof(GetDepartmentById), new { id = departmentReadDto.OddzialID }, departmentReadDto);
            return Ok(departmentReadDto);
            
        }
        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(int id, OddzialCreateDTO oddzialCreateDTO)
        {
            var departmentModelFromRepo = _repository.GetDepartmentById(id);
            if (departmentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(oddzialCreateDTO, departmentModelFromRepo);
            _repository.UpdateDepartment(departmentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            var departmentModelFromRepo = _repository.GetDepartmentById(id);
            if (departmentModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDepartment(departmentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
