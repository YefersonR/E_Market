using E_Market.Core.Application.Helpers;
using E_Market.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;

namespace WebApp.Market.Middleware
{
    public class UserSession
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public bool hasUser()
        {
            UserViewModel userViewModel = _httpContext.HttpContext.Session.Get<UserViewModel>("usuario");
            return userViewModel == null ? false : true;
        }
    }
}
