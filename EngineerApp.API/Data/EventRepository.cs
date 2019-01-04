using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngineerApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerApp.API.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        public EventRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<IncidentHistory>> GetIncidents()
        {
            var events = await _context.IncidentsHistory.ToListAsync();

            return events;
        }
    }
}