using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Queries;
using BuildingBlocks.Abstractions.Persistence.EfCore;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.Authentication.Authenticate;

public class AuthenticateQueryHandler : IQueryHandler<AuthenticateQuery, AuthenticationResult>
{
    private readonly IConnectionFactory _connectionFactory;

    internal AuthenticateQueryHandler(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<AuthenticationResult> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
    {
        var connection = _connectionFactory.GetOrCreateConnection();

        const string sql = "SELECT " +
                           "[User].[Id], " +
                           "[User].[Login], " +
                           "[User].[Name], " +
                           "[User].[Email], " +
                           "[User].[IsActive], " +
                           "[User].[Password] " +
                           "FROM [users].[v_Users] AS [User] " +
                           "WHERE [User].[Login] = @Login";

        var user = await connection.QuerySingleOrDefaultAsync<UserDto>(
            sql,
            new
            {
                request.Login,
            });

        if (user == null)
        {
            return new AuthenticationResult("Incorrect login or password");
        }

        if (!user.IsActive)
        {
            return new AuthenticationResult("User is not active");
        }

        if (!PasswordManager.VerifyHashedPassword(user.Password, request.Password))
        {
            return new AuthenticationResult("Incorrect login or password");
        }

        user.Claims = new List<Claim>
        {
            new Claim(CustomClaimTypes.Name, user.Name),
            new Claim(CustomClaimTypes.Email, user.Email)
        };

        return new AuthenticationResult(user);
    }
}
