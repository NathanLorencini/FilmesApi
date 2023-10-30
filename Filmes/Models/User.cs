using Microsoft.AspNetCore.Identity;

namespace Filmes.Models;

public class User : IdentityUser
{
    public DateTime DateBirth { get; set; }


    public User() : base() { }
}