using AutoMapper;
using DataAccess;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Services;

public class UsersService
{
    private readonly IBaseRepository _repository;
    private readonly IMapper _mapper;

    public UsersService(IBaseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        return await _repository.ReadAsync<UserDTO>(id);
    }

    public async Task<UserDTO> CreateUserAsync(UserDTO user)
    {
        var created = await _repository.CreateAsync(_mapper.Map<User>(user));
        return _mapper.Map<UserDTO>(created);
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