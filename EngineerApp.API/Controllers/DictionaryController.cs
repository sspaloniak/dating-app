using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using EngineerApp.API.Data;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EngineerApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly ISystemDictionaryRepository _repo;
        private readonly IMapper _mapper;

        public DictionaryController(ISystemDictionaryRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("departments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _repo.GetDepartments();

            return Ok(departments);
        }

        [HttpGet("departments/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _repo.GetDepartment(id);

            return Ok(department);
        }

        [HttpGet("superiors")]
        public async Task<IActionResult> GetSuperiors()
        {
            var users = await _repo.GetSuperiors();

            var superiors = new List<Superior>();

            foreach (var user in users)
            {
                Superior superior = new Superior();

                superior.Id = user.Id;
                superior.SuperiorName = user.Name + " " + user.Surname;
                superiors.Add(superior);
            }

            return Ok(superiors);
        }

        [HttpGet("superiors/{id}")]
        public async Task<IActionResult> GetSuperior(int id)
        {
            var user = await _repo.GetSuperior(id);

            Superior superior = new Superior();

            superior.Id = user.Id;
            superior.SuperiorName = user.Name + " " + user.Surname;

            return Ok(superior);
        }

        [HttpGet("localizations")]
        public async Task<IActionResult> GetLocalizations()
        {
            var localizations = await _repo.GetLocalizations();

            return Ok(localizations);
        }

        [HttpGet("cardreaders")]
        public async Task<IActionResult> GetCardReaders()
        {
            var cardreaders = await _repo.GetCardReaders();
            var localizations = await _repo.GetLocalizations();

            var readers = new List<Reader>();

            foreach (var cardreader in cardreaders)
            {
                Reader readerToReturn = new Reader();

                readerToReturn.Id = cardreader.Id;
                readerToReturn.IdLocalization = cardreader.IdLocalization;
                readerToReturn.Localization = localizations.FirstOrDefault(x => x.Id == cardreader.IdLocalization).Area;
                readerToReturn.ReaderName = cardreader.ReaderName;
                readers.Add(readerToReturn);
            }

            return Ok(readers);
        }






        [HttpPost("departments/add")]
        public async Task<IActionResult> AddDepartment(DepartmentDto department)
        {
            if (await _repo.DepartmentExists(department.DepartmentName))
                return BadRequest("Department already exists.");
            var departmentToCreate = new Department
            {
                DepartmentName = department.DepartmentName,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            };
            _repo.Add(departmentToCreate);

            return StatusCode(201);
        }
                
        [HttpDelete("departments/delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _repo.GetDepartment(id);
            _repo.Delete(department);
            bool result = await _repo.SaveAll();

            return Ok(result);
        }

        [HttpPost("localizations/add")]
        public async Task<IActionResult> AddLocalization(LocalizationDto localization)
        {
            if (await _repo.LocalizationExists(localization.Area))
                return BadRequest("Localization already exists.");
            var localizationToCreate = new Localization
            {
                Area = localization.Area,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            }; 
            _repo.Add(localizationToCreate);

            return StatusCode(201);
        }

        [HttpDelete("localizations/delete/{id}")]
        public async Task<IActionResult> DeleteLocalization(int id)
        {
            var localization = await _repo.GetLocalization(id);
            _repo.Delete(localization);
            bool result = await _repo.SaveAll();

            return Ok(result);
        }

        [HttpPost("cardreaders/add")]
        public async Task<IActionResult> AddCardReader(CardReaderDto cardReader)
        {
            if (await _repo.CardReaderExists(cardReader.ReaderName, cardReader.IdLocalization))
                return BadRequest("Card Reader already exists.");
            var cardReaderToCreate = new CardReader
            {
                IdLocalization = cardReader.IdLocalization,
                ReaderName = cardReader.ReaderName,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            }; 
            _repo.Add(cardReaderToCreate);

            return StatusCode(201);
        }

        [HttpDelete("cardreaders/delete/{id}")]
        public async Task<IActionResult> DeleteCardReader(int id)
        {
            var cardReader = await _repo.GetCardReader(id);
            _repo.Delete(cardReader);
            bool result = await _repo.SaveAll();

            return Ok(result);
        }
    }
}