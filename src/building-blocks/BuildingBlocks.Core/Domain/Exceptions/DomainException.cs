﻿using System.Net;
using BuildingBlocks.Core.Exception.Types;

namespace BuildingBlocks.Core.Domain.Exceptions;

public class DomainException : CustomException
{
    public DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
    {
        StatusCode = statusCode;
    }
}