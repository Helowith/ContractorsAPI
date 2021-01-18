using AutoMapper;
using ContractorsAPI.ContractorsStatus;
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
    [Route("api/kontrahenci")]
    [ApiController]
    public class KontrahentController : ControllerBase
    {
        private readonly IKontrahentRepo _repository;
        private readonly IMapper _mapper;

        public KontrahentController(IKontrahentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IList<Object>> GetAllContractors()
        {
            var contractorsItems = _repository.GetAllContractors();
            if (contractorsItems == null)
            {
                return NotFound();
            }
            //var commandReadDto = _mapper.Map<KontrahentReadDTO>(contractorsItems);
            return Ok(contractorsItems);
            //return Ok(_mapper.Map<IEnumerable<KontrahentReadDTO>>(contractorsItems));
        }
        [HttpGet("{id}")]
        public ActionResult<IList<Object>> GetContractorById(int id)
        {
            var contractorItems = _repository.GetContractorByIdWithAllData(id);
            if(contractorItems == null)
            {
                return NotFound();
            }
            //return Ok(_mapper.Map<KontrahentReadDTO>(contractorItems));
            return Ok(contractorItems);
        }
        
        [HttpPost]
        public ActionResult<IList<Object>> CreateContractor(KontrahentCreateDTO kontrahentCreateDTO)
        {
            
            var contractorItems = _mapper.Map<Kontrahent>(kontrahentCreateDTO);
            _repository.CreateContractor(contractorItems);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<KontrahentReadDTO>(contractorItems);
            return Ok(commandReadDto);
        } 

        [HttpPut("{id}")]
        public ActionResult UpdateContractor(int id, KontrahentUpdateDTO kontrahentUpdateDTO)
        {
            var contratorModelFromRepo = _repository.GetContractorById(id);
            if(contratorModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(kontrahentUpdateDTO, contratorModelFromRepo);
            _repository.UpdateContractor(contratorModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContractor(int id)
        {
            var contratorModelFromRepo = _repository.GetContractorById(id);
            if (contratorModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteContractor(contratorModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        [Route("outside")]
        [HttpGet("nip")]
        public ActionResult<KontrahentOutsideDTO> GetByNip(string nip)
        {
            var kontrahent = _repository.GetContractorByNip(nip);
            if (kontrahent.ID == -1)
            {
                return NotFound();
            }
            return Ok(kontrahent);
        }
        [Route("{id}/invoices")]
        [HttpPost]
        public ActionResult<Sum> GetContractorInvoices(int id, KontrahentGetInvoicesDTO kontrahentGetInvoicesDTO)
        {
            var contractor = _repository.GetContractorById(id);

            
            return Ok(_repository.GetInvoices(contractor.NIP, kontrahentGetInvoicesDTO.dateFromDateTime, kontrahentGetInvoicesDTO.dateToDateTime));
        }
    }
}
