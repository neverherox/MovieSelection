using System.Security.Claims;
using MovieSelection.Data.Context;
using MovieSelection.Models.Entities;

namespace MovieSelection.Api.Extensions
{
    public class CheckUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, MovieSelectionContext dbContext)
        {
            if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)context.User.Identity;
                var userIdClaim = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                var userId = Guid.Parse(userIdClaim.Value);
                var user = await dbContext.Users.FindAsync(userId);
                if (user == null)
                {
                    var userName = identity.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                    user = new User
                    {
                        Id = userId,
                        Name = userName
                    };
                    dbContext.Users.Add(user);
                    await dbContext.SaveChangesAsync();
                }
            }
            await _next(context);
        }
    }

}
