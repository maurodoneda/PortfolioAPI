using DataAccess;
using Domain.DTOs;

namespace Application.Services;

public class UserService
{
    private readonly IBaseRepository _repository;

    public UserService(IBaseRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        return await _repository.ReadAsync<UserDTO>(id);
    }

    public async Task<UserDTO> CreateUserAsync(UserDTO user)
    {
        return await _repository.CreateAsync(user);
    }

    public async Task<UserDTO> UpdateUserAsync(UserDTO user)
    {
        return await _repository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(UserDTO user)
    {
        await _repository.DeleteAsync(user);
    }
}