using E_Market.Core.Application.Helpers;
using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.ViewModels.User;
using E_Market.Core.Domain.Entities;
using E_Market.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly E_MarketContext _MarketContext;
        public UserRepository(E_MarketContext marketContext):base(marketContext)
        {
            _MarketContext = marketContext;
        }
        public override async Task<User> AddAsync(User type)
        {
            type.Password = PasswordEncryption.ComputeHash(type.Password);
            return await base.AddAsync(type);
        }
        public async Task<User> LoginAsync(LoginViewModel type)
        {
            type.Password = PasswordEncryption.ComputeHash(type.Password);
            User user = await _MarketContext.Set<User>().FirstOrDefaultAsync(usuario => type.UserName == usuario.UserName && type.Password == usuario.Password);
            
            return user;
        }
    }
}
