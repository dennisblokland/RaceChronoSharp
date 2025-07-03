using System;

namespace RaceChronoSharp
{
    public class RaceChronoSessionMetadata
    {
        public string? Format { get; set; }
        public string? SessionTitle { get; set; }
        public string? SessionType { get; set; }
        public string? TrackName { get; set; }
        public string? DriverName { get; set; }
        public DateTime? Created { get; set; }
        public string? Note { get; set; }
    }
}