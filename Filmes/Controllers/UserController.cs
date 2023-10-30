using Filmes.Data.Dtos;
using Filmes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private UserService _userService;


    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser(CreateUserDto userDto)
    {
        await _userService.Cadastre(userDto);

        return Ok("User Creating");
    }


    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserDto LoginDto)
    {
       var token = await _userService.Login(LoginDto);
        
       return Ok(token);
    }

}