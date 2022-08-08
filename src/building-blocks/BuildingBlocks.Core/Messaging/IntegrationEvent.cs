using BuildingBlocks.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Messaging;

public record IntegrationEvent : Message, IIntegrationEvent;
