using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Users.GetUser;

public class UserDto
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }
}
