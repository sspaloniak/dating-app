using System.Collections.Generic;
using System.Threading.Tasks;
using EngineerApp.API.Models;

namespace EngineerApp.API.Data
{
    public interface ISystemDictionaryRepository
    {
        void Add<T> (T entity) where T: class;
        void AddDepart(Department entity);
        void Delete<T> (T entity) where T: class;

        Task<Department> GetDepartment(int id);
        Task<IEnumerable<Department>> GetDepartments();

        Task<CardReader> GetCardReader(int id);
        Task<IEnumerable<CardReader>> GetCardReaders();

        Task<Localization> GetLocalization(int id);
        Task<IEnumerable<Localization>> GetLocalizations();

        Task<User> GetSuperior(int id);
        Task<IEnumerable<User>> GetSuperiors();

        Task<bool> DepartmentExists(string element);
        Task<bool> LocalizationExists(string element);
        Task<bool> CardReaderExists(string element, int elementInt);
        Task<bool> SaveAll();
    }
}