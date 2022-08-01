using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Exception.Types;

public class InvalidDateException : BadRequestException
{
    public DateTime Date { get; }

    public InvalidDateException(DateTime date) : base($"Date: '{date}' is invalid.")
    {
        Date = date;
    }
}
