using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Members;

public class Member : Aggregate<MemberId>
{
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

    public static Member Create(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        return new Member(id, login, email, firstName, lastName, name);
    }

    private Member(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        this.Id = new MemberId(id);
        _login = login;
        _email = email;
        _firstName = firstName;
        _lastName = lastName;
        _name = name;
        _createDate = DateTime.Now;

        //this.AddDomainEvent(new MemberCreatedDomainEvent(this.Id));
    }
}
