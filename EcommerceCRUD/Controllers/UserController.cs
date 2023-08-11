using EcommerceCRUD.Models.DTO.Input;
using EcommerceCRUD.Models.DTO.Output;
using EcommerceCRUD.Repositories;
using EcommerceCRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(UserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(String id)
        {
            var userCreated = await _userService.Get(id);

            return Ok(new ResponseObject(200, OutputUser.MapUserToUserOutput(userCreated)));
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(String id, [FromBody] InputUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.Update(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
