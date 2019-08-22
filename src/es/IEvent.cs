﻿using System;

namespace es
{
    public interface IEvent
    {
        int Sequence { get; }
        DateTimeOffset Timestamp { get; }
        string Kind { get; }
        string PrimaryAggregate { get; }
        Guid Subject { get; }
        string Data { get; }
    }
}
