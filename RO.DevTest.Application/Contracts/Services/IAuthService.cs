using RO.DevTest.Domain.Entities;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Contracts.Services;

public interface IAuthService
{
    Task<string?> LoginAsync(string username, string password);
    Task<string?> RegisterAsync(string username, string password, string email, string name);
}