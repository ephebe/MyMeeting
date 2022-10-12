using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Domain;

public interface IHaveAudit : IHaveCreator
{
    DateTime? LastModified { get; }
    Guid? LastModifiedBy { get; }
}
