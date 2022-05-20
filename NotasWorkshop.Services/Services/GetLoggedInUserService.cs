using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Services.Services
{
    public interface IGetLoggedInUserService
    {
        public string Role { get; }
        public string Email { get; }
        public int UserId { get; }
    }
    public class GetLoggedInUserService: IGetLoggedInUserService
    {
        public GetLoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            Role = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role).Value;
            Email = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email).Value;
        }

        public string Role { get; }
        public string Email { get; }
        public int UserId { get; }
    }
}
