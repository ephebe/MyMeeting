using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.CQRS.Events;
using BuildingBlocks.Core.Exception;
using BuildingBlocks.Security.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyMeeting.Services.Identity.Application.ApplicationUsers.Exceptions;
using MyMeeting.Services.Identity.Application.Tokens.GenerateJwtToken;
using MyMeeting.Services.Identity.Application.Tokens.GenerateRefreshToken;
using MyMeeting.Services.Identity.Core.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly ICommandProcessor _commandProcessor;
    private readonly IJwtService _jwtService;
    private readonly JwtOptions _jwtOptions;
    private readonly ILogger<LoginCommandHandler> _logger;
    private readonly IQueryProcessor _queryProcessor;
    private readonly IEventProcessor _eventProcessor;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginCommandHandler(
        UserManager<ApplicationUser> userManager,
        ICommandProcessor commandProcessor,
        IQueryProcessor queryProcessor,
        IEventProcessor eventProcessor,
        IJwtService jwtService,
        IOptions<JwtOptions> jwtOptions,
        SignInManager<ApplicationUser> signInManager,
        ILogger<LoginCommandHandler> logger)
    {
        _userManager = userManager;
        _commandProcessor = commandProcessor;
        _queryProcessor = queryProcessor;
        _eventProcessor = eventProcessor;
        _jwtService = jwtService;
        _signInManager = signInManager;
        _jwtOptions = jwtOptions.Value;
        _logger = logger;
    }

    public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command, nameof(Login));

        var identityUser = await _userManager.FindByNameAsync(command.UserNameOrEmail) ??
                           await _userManager.FindByEmailAsync(command.UserNameOrEmail);

        Guard.Against.Null(identityUser, new UserNotFoundException(command.UserNameOrEmail));

        // instead of PasswordSignInAsync, we use CheckPasswordSignInAsync because we don't want set cookie, instead we use JWT
        var signinResult = await _signInManager.CheckPasswordSignInAsync(
            identityUser,
            command.Password,
            false);

        if (signinResult.IsNotAllowed)
        {
            if (!await _userManager.IsEmailConfirmedAsync(identityUser))
                throw new EmailNotConfirmedException(identityUser.Email);

            if (!await _userManager.IsPhoneNumberConfirmedAsync(identityUser))
                throw new PhoneNumberNotConfirmedException(identityUser.PhoneNumber);
        }
        else if (signinResult.IsLockedOut)
        {
            throw new UserLockedException(identityUser.Id.ToString());
        }
        else if (signinResult.RequiresTwoFactor)
        {
            throw new RequiresTwoFactorException("Require two factor authentication.");
        }
        else if (!signinResult.Succeeded)
        {
            throw new PasswordIsInvalidException("Password is invalid.");
        }

        var refreshToken =
            (await _commandProcessor.SendAsync(
                new GenerateRefreshTokenCommand { UserId = identityUser.Id },
                cancellationToken)).RefreshToken;

        var accessToken =
            await _commandProcessor.SendAsync(
                new GenerateJwtTokenCommand(identityUser, refreshToken.Token),
                cancellationToken);



        _logger.LogInformation("User with ID: {ID} has been authenticated", identityUser.Id);

        // we can don't return value from command and get token from a short term session in our request with `TokenStorageService`
        return new LoginResponse(identityUser, accessToken, refreshToken.Token);
    }
}
