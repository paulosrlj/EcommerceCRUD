using EcommerceCRUD.Models.DTO.Entities;
using EcommerceCRUD.Models.DTO.Input;
using EcommerceCRUD.Repositories;
using EcommerceCRUD.Services.Interfaces;

namespace EcommerceCRUD.Services
{
    public class UserService : IUserService
    {

        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Get(string id)
        {
            return await _userRepository.Get(Guid.Parse(id));
        }

        public async Task<User> Create(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task Update(string id, InputUser inputUser)
        {
            User user = await Get(id);

            User updatedUser = UpdateUserFields(inputUser, user);
            await _userRepository.Update(updatedUser);

        }

        public async Task Delete(string id)
        {
            await _userRepository.Delete(Guid.Parse(id));
        }

        private User UpdateUserFields(InputUser inputUser, User user)
        {
            user.Name = inputUser.Name;
            user.Email = inputUser.Email;
            user.HashedPassword = inputUser.Password;
            return user;
        }
    }
}
