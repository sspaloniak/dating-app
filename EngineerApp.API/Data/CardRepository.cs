using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerApp.API.Data
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;
        public CardRepository(DataContext context)
        {
            _context = context;
        }   

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task<bool> CardExists(CardForListDto card)
        {
            if (await _context.Cards.AnyAsync(x => x.IdUser == card.IdUser && x.CardNumber1 == card.CardNumber1 && x.CardNumber2 == card.CardNumber2 && x.CardNumber3 == card.CardNumber3 && x.CardNumber4 == card.CardNumber4))
                return true;

            return false;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<Card> GetCard(int id)
        {
            var card = _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

            return card;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            var cards = await _context.Cards.ToListAsync();

            return cards;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}