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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var usersToReturn = _mapper.Map<IEnumerable<User>, IEnumerable<UserForListDto>>(users);

            foreach (var user in usersToReturn)
            {
                if (user.IdSuperior != 0)
                {
                    var userTemp = _repo.GetUser(user.IdSuperior);
                    if(userTemp.Result != null)
                    {
                        user.Superior = userTemp.Result.Name + " " + userTemp.Result.Surname;
                    }
                    else
                    {
                        user.Superior = "Przydzielony przełożony nie istnieje.";
                    }
                }
                else
                    user.Superior = "";

                if (user.IdDepartment != 0)
                {
                    var departmentTemp = _repo.GetUserDepartment(user.IdDepartment);
                    if(departmentTemp.Result != null)
                    {
                        user.Department = departmentTemp.Result.DepartmentName;
                    }
                    else
                    {
                        user.Department = "Przydzielony dział nie istnieje.";
                    }
                }
                else
                    user.Department = "Brak";
            }

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDTO>(user);

                if (userToReturn.IdSuperior != 0)
                {
                    var userTemp = _repo.GetUser(userToReturn.IdSuperior);
                    if(userTemp.Result != null)
                    {
                        userToReturn.Superior = userTemp.Result.Name + " " + userTemp.Result.Surname;
                    }
                    else
                    {
                        userToReturn.Superior = "Przydzielony przełożony nie istnieje.";
                    }
                }
                else
                    userToReturn.Superior = "";
                    
                if (userToReturn.IdDepartment != 0)
                {
                    var departmentTemp = _repo.GetUserDepartment(userToReturn.IdDepartment);
                    if(departmentTemp.Result != null)
                    {
                        userToReturn.Department = departmentTemp.Result.DepartmentName;
                    }
                    else
                    {
                        userToReturn.Department = "Przydzielony dział nie istnieje.";
                    }
                }
                else
                    userToReturn.Department = "Brak";

            return Ok(userToReturn);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repo.GetUser(id);
            _repo.Delete(user);
            bool result = await _repo.SaveAll();

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser(UserForDetailedDTO userToUpdate)
        {
            var result = await _repo.UpdateUser(userToUpdate);

            return Ok(result);
        }
    }
}