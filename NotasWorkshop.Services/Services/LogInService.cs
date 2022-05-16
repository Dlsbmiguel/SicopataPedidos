using AutoMapper;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.Repositories;
using SicopataPedidos.Model.UnitOfWorks;

namespace SicopataPedidos.Services.Services
{
    public interface ILogInService
    {
        Task<string?> AuthenticateUser(LogInDto request);
    }

    public class LogInService : ILogInService
    {
        private readonly ITokenCreationService _tokenService;
        public LogInService(ITokenCreationService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<string?> AuthenticateUser(LogInDto request)
        {
            var validUser = await _tokenService.ValidateUser(request);

            if (validUser == null) return null;

            var token = _tokenService.CreateToken(validUser);

            return token;
        }
    }

}
