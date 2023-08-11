using EcommerceCRUD.Entities;
using EcommerceCRUD.Models.DTO.Input;
using EcommerceCRUD.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<User> Create([FromBody] InputUser user)
        {
            var userCreated = await _userRepository.Create(InputUser.MapUserDtoToUser(user));
            return userCreated;
        }
    }
}
