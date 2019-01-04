using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using EngineerApp.API.Data;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}