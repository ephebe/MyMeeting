using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Messaging;
using BuildingBlocks.Abstractions.Messaging.PersistMessage;
using Microsoft.AspNetCore.Identity;
using ApplicationRoles = MyMeeting.Services.Identity.Core.ApplicationRoles
using MyMeeting.Services.Identity.Application.Identity.GenerateRefreshToken;
using MyMeeting.Services.Identity.Application.Users.Dtos;
using MyMeeting.Services.Identity.Application.Users.Exceptions;
using MyMeeting.Services.Identity.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeeting.Services.Identity.Core.Users.Events;

namespace MyMeeting.Services.Identity.Application.Users.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IMessagePersistenceService _messagePersistenceService;

    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager,
        IMessagePersistenceService messagePersistenceService)
    {
        _messagePersistenceService = messagePersistenceService;
        _userManager = Guard.Against.Null(userManager, nameof(userManager));
    }
    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
            UserState = UserState.Active,
            CreatedAt = request.CreatedAt,
        };

        var identityResult = await _userManager.CreateAsync(applicationUser, request.Password);
        var roleResult = await _userManager.AddToRolesAsync(
            applicationUser,
            request.Roles ?? new List<string> { ApplicationRoles.IdentityConstants.Role.User });

        if (!identityResult.Succeeded)
            throw new RegisterIdentityUserException(string.Join(',', identityResult.Errors.Select(e => e.Description)));

        if (!roleResult.Succeeded)
            throw new RegisterIdentityUserException(string.Join(',', roleResult.Errors.Select(e => e.Description)));


        var userRegistered = new NewUserRegisteredDomainEvent(
            applicationUser.Id,
            applicationUser.Email,
            applicationUser.UserName,
            applicationUser.FirstName,
            applicationUser.LastName,
            request.Roles);

        // publish our integration event and save to outbox should do in same transaction of our business logic actions. we could use TxBehaviour or ITxDbContextExecutes interface
        // This service is not DDD, so we couldn't use DomainEventPublisher to publish mapped integration events
        await _messagePersistenceService.AddPublishMessageAsync(
            new MessageEnvelope<UserRegistered>(userRegistered, new Dictionary<string, object?>()), cancellationToken);

        return new RegisterUserResult(new IdentityUserDto
        {
            Id = applicationUser.Id,
            Email = applicationUser.Email,
            UserName = applicationUser.UserName,
            FirstName = applicationUser.FirstName,
            LastName = applicationUser.LastName,
            Roles = request.Roles ?? new List<string> { IdentityConstants.Role.User },
            RefreshTokens = applicationUser?.RefreshTokens?.Select(x => x.Token),
            CreatedAt = request.CreatedAt,
            UserState = UserState.Active
        });
    }
}
