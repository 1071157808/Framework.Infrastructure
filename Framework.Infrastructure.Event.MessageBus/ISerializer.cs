﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Infrastructure.Event.MessageBus
{
    public interface ISerializer
    {
        byte[] MessageToBytes<T>(T message);
        T BytesToMessage<T>(byte[] bytes);
    }
}
