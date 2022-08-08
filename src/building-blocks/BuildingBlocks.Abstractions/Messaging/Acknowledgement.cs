using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// 承認?感謝?
/// </summary>
public abstract class Acknowledgement
{
}

public class Ack : Acknowledgement
{
}

public class Nack : Acknowledgement
{
    public Nack(Exception exception, bool requeue = true)
    {
        Requeue = requeue;
        Exception = exception;
    }

    public bool Requeue { get; }
    public Exception Exception { get; }
}

public class Reject : Acknowledgement
{
    public bool Requeue { get; }

    public Reject(bool requeue = true)
    {
        Requeue = requeue;
    }
}
