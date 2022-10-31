using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassRoom.API.Extensions;
using ClassRoom.Application.Contratos;
using ClassRoom.Application.Dtos;
using ClassRoom.Persistence.Contratos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClassRoom.API.Controllers
{
    [Authorize]
    [ApiController]
    
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        
        public AccountController(IAccountService accountService,
                                 ITokenService tokenService)
        {
            _tokenService = tokenService;
            _accountService = accountService;          
        }

        [HttpGet("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar User. Erro {ex.Message}");
            }

        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                if (await _accountService.UserExists(userDto.UserName))
                    return BadRequest("Usuario existente");

                var user = await _accountService.CreateAccountAsync(userDto);
                if (user != null)
                    return Ok(user);
                
                return BadRequest("Usuario não criado");
            }
            catch (Exception ex)
            {          
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar User. Erro {ex.Message}");
            }

        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(userLogin.UserName);
                if(user == null) return Unauthorized("Usuário inexistente");

                var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);
                if(!result.Succeeded) return Unauthorized("senha ou nome errados");

                return  Ok(new
                {   
                    userName = user.UserName,
                    PrimeiroNome = user.PrimeiroNome,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar User. Erro {ex.Message}");
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(User.GetUserName());
                if(user == null) return Unauthorized("usuario invalido");
                
                var userReturn = await _accountService.UpdateAccount(userUpdateDto);
                if(userReturn == null)
                    return NoContent();

                return Ok(userReturn);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar atualisar User. Erro {ex.Message}");
            }
        }
    }
}