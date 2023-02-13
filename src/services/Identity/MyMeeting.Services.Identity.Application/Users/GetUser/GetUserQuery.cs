using BuildingBlocks.Abstractions.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Users.GetUser;

public record GetUserQuery(Guid userId)
    : IQuery<UserDto>;

