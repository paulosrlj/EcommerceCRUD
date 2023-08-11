using EcommerceCRUD.Models.DTO.Input;
using EcommerceCRUD.Models.DTO.Output;
using EcommerceCRUD.Repositories;
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
        public async Task<IActionResult> Create([FromBody] InputUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userCreated = await _userRepository.Create(InputUser.MapUserDtoToUser(user));
            return Ok(new ResponseObject(200, OutputUser.MapUserToUserOutput(userCreated)));
        }
    }
}
