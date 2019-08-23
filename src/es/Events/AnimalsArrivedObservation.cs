using System;

namespace es.Events 
{
    public class AnimalArrivedObservation
    {
        public DateTimeOffset Arrived { get; set; }
        public Guid AnimalId { get; set; }
        public string From { get; set; }
    }
}