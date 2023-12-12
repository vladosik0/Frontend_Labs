using BSATask.DAL.Models.Users;

namespace BSATask.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserCreateDto> CreateUser(UserCreateDto userDto);
        Task<UserEditDto> UpdateUser(UserEditDto userDto);
        System.Threading.Tasks.Task DeleteUser(int id);
    }
}
