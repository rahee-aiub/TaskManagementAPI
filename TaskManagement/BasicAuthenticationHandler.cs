using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

        string authorizationHeader = Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authorizationHeader))
            return AuthenticateResult.Fail("Missing Authorization Header");

        if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            return AuthenticateResult.Fail("Invalid Authorization Header");

        string encodedUsernamePassword = authorizationHeader.Substring("Basic ".Length).Trim();
        byte[] decodedBytes = Convert.FromBase64String(encodedUsernamePassword);
        string decodedText = Encoding.UTF8.GetString(decodedBytes);
        string[] usernamePassword = decodedText.Split(':', 2);

        if (usernamePassword.Length < 2)
            return AuthenticateResult.Fail("Invalid Authorization Header");

        string username = usernamePassword[0];
        string password = usernamePassword[1];

        // TODO: Add your custom authentication logic here
        if (IsValidUser(username, password))
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
        else
        {
            return AuthenticateResult.Fail("Invalid username or password");
        }
    }

    private bool IsValidUser(string username, string password)
    {
        // TODO: Add your custom logic to validate the username and password
        // For example, you can check against a database or any other authentication mechanism
        return username == "admin" && password == "admin";
    }
}
