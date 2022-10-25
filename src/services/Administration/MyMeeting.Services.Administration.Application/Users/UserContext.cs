using BuildingBlocks.Abstractions.Web;
using MyMeeting.Services.Administration.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.Users;

public class UserContext : IUserContext
{
    private readonly IExecutionContextAccessor _executionContextAccessor;

    public UserContext(IExecutionContextAccessor executionContextAccessor)
    {
        this._executionContextAccessor = executionContextAccessor;
    }

    public UserId UserId => new UserId(_executionContextAccessor.UserId);
}
