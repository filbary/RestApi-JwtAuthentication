using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School2.DTOs;
using School2.Extensions;
using School2.Services.Interfaces;
using static School2.Helpers.Consts;

namespace School2.Controllers
{
    [ApiController]
    [Route(Rests.Users)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet(Rests.UserByEmail)]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await _userService.GetUserByEmailAsync(email));
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(UserDto dto)
        {
            await _userService.CreateNewUser(dto);
            return Ok();
        }

        [HttpPost(Rests.Register)]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterUser(UserCredDto dto)
        {
            await _userService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost(Rests.Login)]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginUser(UserCredDto dto)
        {
            var user = await _userService.GetByUsername(dto.Username);
            if (user == null)
            {
                return BadRequest(Messages.WRONGNAMEORPASS);
            }
            if (dto.Password.VerifyPasswordHash(user.Password, user.PasswordSalt))
            {
                return Ok(_tokenService.CreateToken(user));
            }

            return Ok();
        }
    }
}
