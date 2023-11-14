using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AuthServer.Web.Endpoints
{
    public class Login
    {
        internal static async Task<IResult> Handler(
            HttpContext httpContext,
            string returnUrl)
        {
            await httpContext.SignInAsync("cookie",
                new ClaimsPrincipal(
                        new ClaimsIdentity(
                                new Claim[]
                                {

                                    new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString())
                                },
                                "cookie"
                            )
                    ));

            return Results.Redirect(returnUrl);
        }
    }
}
