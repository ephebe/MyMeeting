using BuildingBlocks.Core.Domain;
using MyMeeting.Services.Administration.Core.Members.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.Members;

public class Member : Aggregate<MemberId>
{
    public MemberId Id { get; private set; }

    private string _login;

    private string _email;

    private string _firstName;

    private string _lastName;

    private string _name;

    private DateTime _createDate;

    private Member()
    {
        // Only for EF.
    }

    private Member(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        this.Id = new MemberId(id);
        _login = login;
        _email = email;
        _firstName = firstName;
        _lastName = lastName;
        _name = name;
        _createDate = DateTime.UtcNow;

        this.AddDomainEvents(new MemberCreatedDomainEvent(this.Id));
    }

    public static Member Create(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        return new Member(id, login, email, firstName, lastName, name);
    }
}
