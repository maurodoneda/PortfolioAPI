namespace Domain.DTOs;

public record UserDTO
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}