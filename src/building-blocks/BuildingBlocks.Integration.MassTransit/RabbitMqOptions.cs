﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Integration.MassTransit;

public class RabbitMqOptions
{
    public string Host { get; set; } = "localhost";
    public string UserName { get; set; } = "guest";
    public string Password { get; set; } = "guest";
    public string ConnectionString => $"amqp://{UserName}:{Password}@{Host}/";
}
