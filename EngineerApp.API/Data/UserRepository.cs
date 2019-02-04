using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerApp.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }   
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> UpdateUser(UserToUpdate userToUpdate)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userToUpdate.Id);

            user.Name = userToUpdate.Name;
            user.Surname = userToUpdate.Surname;
            user.TypePermission = userToUpdate.TypePermission;
            user.IdSuperior = userToUpdate.IdSuperior;
            user.IdDepartment = userToUpdate.IdDepartment;
            user.Email = userToUpdate.Email;
            user.ModifiedBy = 1;
            user.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public Task<User> GetUser(int id)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public Task<Department> GetUserDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefaultAsync(x => x.Id == id);

            return department;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}