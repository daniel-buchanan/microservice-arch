using System;

namespace es 
{
    public sealed class EventPayload 
    {
        public Guid Subject { get; set; }
        public string Aggregate { get; set; }
        public string Kind { get; set; }
        public object Data { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}