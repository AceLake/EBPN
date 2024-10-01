using FirebaseAdmin.Auth;
using System.Security.Claims;

namespace EBPN_Network.Middleware;
public class FirebaseAuthenticationMiddleware {

    private readonly RequestDelegate _next;

    public FirebaseAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Cookies.TryGetValue("auth_token", out var token))
        {
            try
            {
                // Verify the Firebase token
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
                var uid = decodedToken.Uid;

                // Add the user information to the HttpContext
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, uid),
                    new Claim(ClaimTypes.Name, decodedToken.Claims["email"].ToString())
                };
                var identity = new ClaimsIdentity(claims, "firebase");
                context.User = new ClaimsPrincipal(identity);
            }
            catch (FirebaseAuthException)
            {
                // Handle invalid or expired token
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
        }

        await _next(context);
    }
}


