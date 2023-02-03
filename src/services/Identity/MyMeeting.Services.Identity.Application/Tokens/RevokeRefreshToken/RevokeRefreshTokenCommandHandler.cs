using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.CQRS.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Identity.Application.ApplicationUsers.Exceptions;
using MyMeeting.Services.Identity.Application.Tokens.GenerateRefreshToken;
using MyMeeting.Services.Identity.Core.RefreshTokens;
using MyMeeting.Services.Identity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Tokens.RevokeRefreshToken;

public class RevokeRefreshTokenCommandHandler : ICommandHandler<RevokeRefreshTokenCommand,Unit>
{
    private readonly IdentityContext _context;

    public RevokeRefreshTokenCommandHandler(IdentityContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(
        RevokeRefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        Guard.Against.Null(request, nameof(RevokeRefreshTokenCommand));

        var refreshToken = await _context.Set<RefreshToken>()
            .FirstOrDefaultAsync(x => x.Token == request.RefreshToken, cancellationToken: cancellationToken);

        if (refreshToken == null)
            throw new RefreshTokenNotFoundException(refreshToken);

        if (!refreshToken.IsRefreshTokenValid())
            throw new InvalidRefreshTokenException(refreshToken);

        // revoke token and save
        refreshToken.RevokedAt = DateTime.Now;
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
