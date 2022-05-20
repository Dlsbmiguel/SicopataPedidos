using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SicopataPedidos.Services.Services
{
    public interface ITokenCreationService
    {
        string CreateToken(User user);
        Task<User?> ValidateUser(LogInDto request);
    }
    public class TokenCreationService : ITokenCreationService
    {
        private readonly IConfiguration _iconfiguration;
        private readonly IUnitOfWork<ISicopataPedidosDbContext> _uow;
        public TokenCreationService(IUnitOfWork<ISicopataPedidosDbContext> uow, IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            _uow = uow;
        }
        public string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.IsAdmin.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration.GetSection("TokenSettings:Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<User?> ValidateUser(LogInDto request)
        {
            var user = await _uow.context.GetDbSet<User>().Where(u => u.Email == request.Email && u.Password == request.Password).FirstOrDefaultAsync();

            if (user == null) return null;

            return user;
        }
    }
}
