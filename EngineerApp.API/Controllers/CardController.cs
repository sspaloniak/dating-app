using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _repo;
        private readonly IUserRepository _repoUser;
        private readonly IMapper _mapper;

        public CardController(ICardRepository repo, IUserRepository repoUser,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _repoUser = repoUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var cards = await _repo.GetCards();

            var cardsToReturn = _mapper.Map<IEnumerable<Card>, IEnumerable<CardForListDto>>(cards);

            foreach (var card in cardsToReturn)
            {
                if (card.IdUser != 0)
                {
                    var userTemp = _repoUser.GetUser(card.IdUser);
                    if(userTemp.Result != null)
                    {
                        card.Username = userTemp.Result.Surname;
                    }
                    else
                    {
                        card.Username = "Brak przydzielonego przełożonego.";
                    }
                }
                else
                    card.Username = "Brak przydzielonego przełożonego.";
            }

            return Ok(cardsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCard(int id)
        {
            var card = await _repo.GetCard(id);

            var cardToReturn = _mapper.Map<CardForListDto>(card);

                if (cardToReturn.IdUser != 0)
                {
                    var userTemp = _repoUser.GetUser(cardToReturn.IdUser);
                    if(userTemp.Result != null)
                    {
                        cardToReturn.Username = userTemp.Result.Surname;
                    }
                    else
                    {
                        cardToReturn.Username = "Brak przydzielonego przełożonego.";
                    }
                }
                else
                    cardToReturn.Username = "Brak przydzielonego przełożonego.";

            return Ok(cardToReturn);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCard(CardForListDto card)
        {
            if (await _repo.CardExists(card))
                return BadRequest("Localization already exists.");
            var cardToCreate = new Card
            {
                CardNumber1 = card.CardNumber1,
                CardNumber2 = card.CardNumber2,
                CardNumber3 = card.CardNumber3,
                CardNumber4 = card.CardNumber4,
                IdUser = card.IdUser,
                Blocked = card.Blocked,
                Add_Date = DateTime.Now,
                LastUse_Date = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            }; 
            _repo.Add(cardToCreate);

            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _repo.GetCard(id);
            _repo.Delete(card);
            bool result = await _repo.SaveAll();

            return Ok(result);
        }
    }
}