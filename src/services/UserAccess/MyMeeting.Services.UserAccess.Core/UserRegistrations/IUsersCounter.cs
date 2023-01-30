using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Core.UserRegistrations;

public interface IUsersCounter
{
    int CountUsersWithLogin(string login);
}
