using System.Collections.Generic;
using System.Threading.Tasks;
using EngineerApp.API.Models;

namespace EngineerApp.API.Data
{
    public interface IEventRepository
    {
        Task<IEnumerable<IncidentHistory>> GetIncidents();
    }
}