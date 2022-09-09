using E_Market.Core.Application.ViewModels.User;
using E_Market.Core.Domain.Entities;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository :IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel type);
    }
}
