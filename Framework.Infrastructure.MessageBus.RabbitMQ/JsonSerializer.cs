﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Framework.Infrastructure.MessageBus.RabbitMQ
{
    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public byte[] MessageToBytes<T>(T message)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, serializerSettings));
        }

        public T BytesToMessage<T>(byte[] bytes)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes), serializerSettings);
        }
    }
}
