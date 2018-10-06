using System;

namespace XaMaps.Models
{
    public class DirectionsSummary
    {
        public long LengthInMeters { get; set; }
        public long TravelTimeInSeconds { get; set; }
        public long TrafficDelayInSeconds { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
    }
}