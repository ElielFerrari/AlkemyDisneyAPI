using BusinessLogic.Dto;


namespace BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(UserDto userDto);
        Task Register(UserDto userDto);
    }
}
