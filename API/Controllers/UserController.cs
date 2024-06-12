using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserRepository> _logger;


        public UserController(IUserRepository userRepository, ILogger<UserRepository> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userRepository.GetUserAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,new
                {
                    statusCode = 500,
                    message = ex.Message
                });
                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "user does not exist"
                    });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = ex.Message
                });

            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Postuser(User Cuser)
        {
            try
            {
                var createduser = await _userRepository.CreateUserAsync(Cuser);

                return Ok(createduser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = ex.Message
                });

            }
        }

        [HttpPut]
        public async Task<IActionResult> Updateuser(User Cuser)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(Cuser.Id);
                if (user == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "user does not exist"
                    });
                }

                await _userRepository.UpdateUserAsync(Cuser);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = ex.Message
                });

            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "user does not exist"
                    });
                }

                await _userRepository.DeleteUserAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = ex.Message
                });

            }
        }

    }
}
