using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepo;
        private readonly IUserRepository _userRepo;

        public EventsController(IEventRepository eventRepo, IUserRepository userRepo)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetIncidents()
        {
            var events = await _eventRepo.GetIncidents();
            var users = await _userRepo.GetUsers();

            var eventsToReturn = new List<Event>();
            foreach(var item in events)
            {
                Event eventItem = new Event();

                eventItem.IdUser = item.IdUser;
                eventItem.User = users.FirstOrDefault(x => x.Id == item.IdUser).Surname;
                eventItem.IdIncidentType = item.IncidentType;
                eventItem.IncidentType = ((TypeOfIncident)item.IncidentType).ToString();
                eventItem.IdCardReader = item.IdCardReader;
                eventItem.Date = item.Date.ToShortDateString() + " " + item.Hour.ToShortTimeString();
                eventItem.CardReader = item.IdCardReader.ToString();
                
                eventsToReturn.Add(eventItem);
            }

            return Ok(eventsToReturn);
        }
    }

    public enum TypeOfIncident
    {
        Wejście = 0, Wyjście = 1, Brak_Dostępu = 2
    };
}