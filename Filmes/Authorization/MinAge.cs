using Microsoft.AspNetCore.Authorization;

namespace Filmes.Authorization;

public class MinAge : IAuthorizationRequirement
{

    public int  Age{ get; set; }

    public MinAge(int age)
    {
        Age = age;
    }
}