using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Services;

public class UserService
{

    private UserManager<User> _context;

    private IMapper _mapper;

    private SignInManager<User> _singnInmanager;
    private TokenService _tokenService;


    public UserService(UserManager<User> context, IMapper mapper, SignInManager<User> singnInmanager, TokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _singnInmanager = singnInmanager;
        _tokenService = tokenService;
    }

    public async Task Cadastre(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);

        IdentityResult result = await 
            _context.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Fail creation user");
        }
    }

    public async Task<string> Login(LoginUserDto loginDto)
    {
        
            var result = await _singnInmanager
                .PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);


        if (!result.Succeeded)
        {
            throw new ApplicationException("User not authenticated");
        }

        var user =_singnInmanager.UserManager.Users.FirstOrDefault(user => user.UserName == loginDto.Username.ToUpper());

        var token = _tokenService.GenerateToken(user);

        return token;
    }
}