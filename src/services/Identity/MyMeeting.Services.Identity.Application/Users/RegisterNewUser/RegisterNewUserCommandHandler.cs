using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Messaging;
using BuildingBlocks.Abstractions.Messaging.PersistMessage;
using ApplicationRoles = MyMeeting.Services.Identity.Core.ApplicationRoles;
using MyMeeting.Services.Identity.Application.Identity.GenerateRefreshToken;
using MyMeeting.Services.Identity.Application.Users.Dtos;
using MyMeeting.Services.Identity.Application.Users.Exceptions;
using MyMeeting.Services.Identity.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeeting.Services.Shared.UserAccess.UserRegistrations.Events.Integration;
using MyMeeting.Services.Identity.Core.ApplicationRoles;
using Microsoft.AspNetCore.Identity;

namespace MyMeeting.Services.Identity.Application.Users.RegisterNewUser;

public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand, RegisterNewUserResult>
{
    private readonly IMessagePersistenceService _messagePersistenceService;

    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterNewUserCommandHandler(UserManager<ApplicationUser> userManager,
        IMessagePersistenceService messagePersistenceService)
    {
        _messagePersistenceService = messagePersistenceService;
        _userManager = Guard.Against.Null(userManager, nameof(userManager));
    }
    public async Task<RegisterNewUserResult> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
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
            request.Roles ?? new List<string> { ApplicationRoles.MeetingIdentityConstants.Role.User });

        if (!identityResult.Succeeded)
            throw new RegisterIdentityUserException(string.Join(',', identityResult.Errors.Select(e => e.Description)));

        if (!roleResult.Succeeded)
            throw new RegisterIdentityUserException(string.Join(',', roleResult.Errors.Select(e => e.Description)));


        var userRegistered = new NewUserRegisteredIntegrationEvent(
            applicationUser.Id,
            applicationUser.UserName,
            applicationUser.Email,
            applicationUser.FirstName,
            applicationUser.LastName,
            $"{applicationUser.FirstName} {applicationUser.LastName}",
             DateTime.UtcNow
            );

        // publish our integration event and save to outbox should do in same transaction of our business logic actions. we could use TxBehaviour or ITxDbContextExecutes interface
        // This service is not DDD, so we couldn't use DomainEventPublisher to publish mapped integration events
        await _messagePersistenceService.AddPublishMessageAsync(
            new MessageEnvelope<NewUserRegisteredIntegrationEvent>(userRegistered, new Dictionary<string, object?>()), cancellationToken);

        return new RegisterNewUserResult(new IdentityUserDto
        {
            Id = applicationUser.Id,
            Email = applicationUser.Email,
            UserName = applicationUser.UserName,
            FirstName = applicationUser.FirstName,
            LastName = applicationUser.LastName,
            Roles = request.Roles ?? new List<string> { MeetingIdentityConstants.Role.User },
            RefreshTokens = applicationUser?.RefreshTokens?.Select(x => x.Token),
            CreatedAt = request.CreatedAt,
            UserState = UserState.Active
        });
    }
}
