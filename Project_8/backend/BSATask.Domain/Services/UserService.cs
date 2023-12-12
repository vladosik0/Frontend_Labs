using AutoMapper;
using BSATask.DAL.Entities;
using BSATask.DAL.Models.Users;
using BSATask.DAL.Repositories.Interfaces;
using BSATask.Domain.Exceptions;
using BSATask.Domain.Services.Interfaces;

namespace BSATask.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;

        public UserService(IMapper mapper, IUserRepository userRepository, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            return _mapper.Map<List<UserDto>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserDto> GetUserById(int id)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(id));
        }

        public async Task<UserCreateDto> CreateUser(UserCreateDto userDto)
        {
            userDto.Id = await _userRepository.FindMaxId(p => p.Id) + 1;

            if (userDto.TeamId.HasValue && !await TeamExist(userDto.TeamId.Value))
            {
                throw new NotFoundException(nameof(Team));
            }

            await _userRepository.CreateAsync(_mapper.Map<User>(userDto));

            return userDto;
        }

        public async Task<UserEditDto> UpdateUser(UserEditDto userDto)
        {
            var userInDb = await _userRepository.GetByIdAsync(userDto.Id);

            if (userInDb == null)
            {
                throw new NotFoundException(nameof(User), userDto.Id);
            }

            if (userDto.TeamId.HasValue && !await TeamExist(userDto.TeamId.Value))
            {
                throw new NotFoundException(nameof(Team));
            }

            var user = _mapper.Map<User>(userDto);
            user.RegisteredAt = userInDb.RegisteredAt;

            await _userRepository.Update(user);

            return userDto;
        }

        public async System.Threading.Tasks.Task DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.Delete(user);
            }
        }

        private async Task<bool> TeamExist(int teamId)
        {
            return await _teamRepository.GetByIdAsync(teamId) != null;
        }
    }
}
