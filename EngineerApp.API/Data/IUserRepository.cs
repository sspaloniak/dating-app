using System.Collections.Generic;
using System.Threading.Tasks;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;

namespace EngineerApp.API.Data
{
    public interface IUserRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
         Task<Department> GetUserDepartment(int id);
         Task<bool> UpdateUser(UserForDetailedDTO userToUpdate);
    }
}