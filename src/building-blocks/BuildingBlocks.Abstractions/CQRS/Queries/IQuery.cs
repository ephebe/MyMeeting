using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Queries;

public interface IQuery<out T> : IRequest<T>
    where T : notnull
{
}

// https://jimmybogard.com/mediatr-10-0-released/
public interface IStreamQuery<out T> : IStreamRequest<T>
    where T : notnull
{
}
