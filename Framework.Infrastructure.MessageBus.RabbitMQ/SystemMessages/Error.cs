﻿using System;
using RabbitMQ.Client;

namespace Framework.Infrastructure.MessageBus.RabbitMQ.SystemMessages
{
    /// <summary>
    /// A wrapper for errored messages
    /// </summary>
    public class Error
    {
        public string RoutingKey { get; set; }
        public string Exchange { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public MessageBasicProperties BasicProperties { get; set; }
    }
}