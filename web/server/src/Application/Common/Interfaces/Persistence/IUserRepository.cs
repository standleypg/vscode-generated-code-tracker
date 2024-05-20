using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<Domain.Entities.User> AddUserAsync(Domain.Entities.User user);
    Task<Domain.Entities.User?> GetUserByEmailAsync(string email);
}