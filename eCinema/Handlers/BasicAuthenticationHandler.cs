﻿using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace eCinema.Handlers;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserService _userService;
    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserService userService) : base(options, logger, encoder, clock)
    {
        _userService = userService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing auth header!");

        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        var credentialyBytes = Convert.FromBase64String(authHeader.Parameter ?? throw new InvalidOperationException());
        var credentials = Encoding.UTF8.GetString(credentialyBytes).Split(":");

        var username = credentials[0];
        var password = credentials[1];

        var user = await _userService.Login(username, password);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, username),
            new Claim(ClaimTypes.Name, user.FirstName!),
            new Claim(ClaimTypes.Role, user.UserRole)
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);

        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        
        return AuthenticateResult.Success(ticket);

    }
}