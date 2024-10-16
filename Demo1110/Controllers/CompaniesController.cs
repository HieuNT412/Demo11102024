using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo1110.DTOs;
using Demo1110.IRepository;
using Demo1110.Model;
using Demo1110.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo1110.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        private readonly ILogger logger1;
        private readonly IMapper _mapper;

        public CompaniesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges: false);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companiesDto);
        }

        [HttpGet("{id}", Name = "CompanyById")]
        public ActionResult GetCompany(Guid id)
        {
            var company = _repository.Company.GetCompany(id, trackChanges: false);

            if (company == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return
         NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }

        [HttpPost]

        public ActionResult CreateCompany(CompanyForCreationDto company)
        {
            if (company == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return BadRequest("CompanyForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CompanyForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var companyEntity = _mapper.Map<Company>(company);
            _repository.Company.CreateCompany(companyEntity);
            _repository.Save();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
            return CreatedAtRoute("CompanyById", new
            {
                id = companyToReturn.Id
            }, companyToReturn);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCompany(Guid id)
        {
            var company = _repository.Company.GetCompany(id, trackChanges: false);

            if (company == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Company.DeleteCompany(company);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public
         ActionResult UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            if (company == null)
            {
                _logger.LogError("CompanyForUpdateDto object sent from client is null.");
                return BadRequest("CompanyForUpdateDto object is null");

            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CompanyForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var companyEntity
         = _repository.Company.GetCompany(id, trackChanges: true);

            if (companyEntity == null)
            {
                _logger.LogInfo($"Company with id: { id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(company, companyEntity);

            _repository.Save();

            return NoContent();
        }


    }
}