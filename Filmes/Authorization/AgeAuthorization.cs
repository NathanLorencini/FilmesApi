using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Filmes.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
        {
            var dataBirthClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (dataBirthClaim is null) return Task.CompletedTask;


            var dateBirth = Convert.ToDateTime(dataBirthClaim.Value);

            var ageUser = DateTime.Today.Year - dateBirth.Year;

            if (dateBirth > DateTime.Today.AddYears(-ageUser)) ageUser--;

            if (ageUser >= requirement.Age) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
