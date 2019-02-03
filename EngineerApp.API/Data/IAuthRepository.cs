using System.Threading.Tasks;
using EngineerApp.API.Dtos;
using EngineerApp.API.Models;

namespace EngineerApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<bool> ChangePassword(PasswordDto password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}