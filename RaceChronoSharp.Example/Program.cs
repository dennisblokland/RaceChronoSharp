using RaceChronoSharp;

RaceChronoSession session = RaceChronoSession.Parse("Example.csv");
Console.WriteLine($"Session Format: {session.Metadata.Format}");
Console.WriteLine($"Session Title: {session.Metadata.SessionTitle}");
Console.WriteLine($"Created: {session.Metadata.Created}");

Console.WriteLine($"Number of Data Points: {session.DataPoints.Count}");
foreach (RaceChronoDataPoint? point in session.DataPoints.Where(x => x.LapNumber != null).OrderByDescending(x => x.Speed2).Take(10)) // Display first 5 data points
{
    double speedKmh = (point.Speed2 ?? 0) * 3.6; // peed in km/h
    Console.WriteLine($"Lap: {point.LapNumber}, Timestamp: {point.Timestamp}, Latitude: {point.Latitude}, Longitude: {point.Longitude}, Speed: {speedKmh:F2} km/h");
}
