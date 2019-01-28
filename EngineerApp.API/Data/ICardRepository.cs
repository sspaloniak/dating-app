using System.Collections.Generic;
using System.Threading.Tasks;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;

namespace EngineerApp.API.Data
{
    public interface ICardRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Card>> GetCards();
         Task<Card> GetCard(int id);
         Task<bool> CardExists(CardForListDto card);
    }
}