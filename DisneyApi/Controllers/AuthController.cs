using BusinessLogic.Dto;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")] //User Register
        public async Task<ActionResult> Register(UserDto userDto)
        {
            try
            {
                await _userService.Register(userDto);
                return Ok($"Usuario con nombre:{userDto.UserName} fue creado exitosamente.");
            }
            catch (DuplicateNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            try
            {
                return Ok(await _userService.Login(userDto));
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.")
;           }
        }
    }
}
