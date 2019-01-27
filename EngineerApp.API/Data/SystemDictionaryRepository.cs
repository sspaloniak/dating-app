using System.Collections.Generic;
using System.Threading.Tasks;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerApp.API.Data
{
    public class SystemDictionaryRepository : ISystemDictionaryRepository
    {
        private readonly DataContext _context;

        public SystemDictionaryRepository(DataContext context)
        {
            _context = context;
        }   
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void AddDepart(Department entity)
        {
            _context.Departments.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<CardReader> GetCardReader(int id)
        {
            var cardReader = _context.CardReaders.FirstOrDefaultAsync(x => x.Id == id);

            return cardReader;
        }

        public async Task<IEnumerable<CardReader>> GetCardReaders()
        {
            var cardReaders = await _context.CardReaders.ToListAsync();

            return cardReaders;
        }

        public Task<Department> GetDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefaultAsync(x => x.Id == id);

            return department;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();

            return departments;
        }

        public Task<User> GetSuperior(int id)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetSuperiors()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public Task<Localization> GetLocalization(int id)
        {
            var localization = _context.Localizations.FirstOrDefaultAsync(x => x.Id == id);

            return localization;
        }

        public async Task<IEnumerable<Localization>> GetLocalizations()
        {
            var localizations = await _context.Localizations.ToListAsync();

            return localizations;
        }

        public async Task<bool> DepartmentExists(string departmentName)
        {
            if (await _context.Departments.AnyAsync(x => x.DepartmentName == departmentName))
                return true;

            return false;
        }

        public async Task<bool> LocalizationExists(string area)
        {
            if (await _context.Localizations.AnyAsync(x => x.Area == area))
                return true;

            return false;
        }

        public async Task<bool> CardReaderExists(string readerName, int idLocalization)
        {
            if (await _context.CardReaders.AnyAsync(x => x.ReaderName == readerName && x.IdLocalization == idLocalization))
                return true;

            return false;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}