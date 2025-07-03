using CsvHelper.Configuration;
using RaceChronoSharp;

public sealed class RaceChronoDataPointMap : ClassMap<RaceChronoDataPoint>
{
    public RaceChronoDataPointMap()
    {
        Map(m => m.Timestamp).Name("timestamp");
        Map(m => m.FragmentId).Name("fragment_id");
        Map(m => m.LapNumber).Name("lap_number");
        Map(m => m.ElapsedTime).Name("elapsed_time");
        Map(m => m.DistanceTraveled).Name("distance_traveled");
        Map(m => m.Accuracy).Name("accuracy");
        Map(m => m.Altitude).Name("altitude");
        Map(m => m.Bearing).Name("bearing");
        Map(m => m.DeviceUpdateRate).Name("device_update_rate").Index(0); // first occurrence
        Map(m => m.FixType).Name("fix_type");
        Map(m => m.Latitude).Name("latitude");
        Map(m => m.Longitude).Name("longitude");
        Map(m => m.Satellites).Name("satellites");
        Map(m => m.Speed).Name("speed").Index(0);
        Map(m => m.CombinedAcc).Name("combined_acc");
        Map(m => m.LateralAcc).Name("lateral_acc");
        Map(m => m.LeanAngle).Name("lean_angle");
        Map(m => m.LongitudinalAcc).Name("longitudinal_acc");
        Map(m => m.Speed2).Name("speed").Index(1); // second occurrence
        // combine both speed fields into one
    }
}
