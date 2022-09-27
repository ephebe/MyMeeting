using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Messaging.MessagePersistence;

public class MessagePersistenceOptions
{
    public int? Interval { get; set; } = 30;
    public string? ConnectionString { get; set; }
    public bool Enabled { get; set; } = true;
}
