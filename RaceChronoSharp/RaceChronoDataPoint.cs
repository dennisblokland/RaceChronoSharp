namespace RaceChronoSharp
{
    public class RaceChronoDataPoint
    {
        public double Timestamp { get; set; } // unix time
        public int? FragmentId { get; set; }
        public int? LapNumber { get; set; }
        public double? ElapsedTime { get; set; } // seconds
        public double? DistanceTraveled { get; set; } // meters
        public double? Accuracy { get; set; } // meters
        public double? Altitude { get; set; } // meters
        public double? Bearing { get; set; } // degrees
        public double? DeviceUpdateRate { get; set; } // Hz
        public string? FixType { get; set; }
        public double? Latitude { get; set; } // degrees
        public double? Longitude { get; set; } // degrees
        public double? Satellites { get; set; }
        public double? Speed { get; set; } // m/s
        public double? CombinedAcc { get; set; } // G
        public double? LateralAcc { get; set; } // G
        public double? LeanAngle { get; set; } // degrees
        public double? LongitudinalAcc { get; set; } // G
        public double? Speed2 { get; set; } // m/s

        public double? SpeedKmh => (Speed2 + Speed) * 3.6; // Convert m/s to km/h
    }
}
