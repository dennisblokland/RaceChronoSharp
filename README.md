# RaceChronoSharp

[![NuGet](https://img.shields.io/nuget/v/RaceChronoSharp.svg)](https://www.nuget.org/packages/RaceChronoSharp)

A .NET library to parse RaceChrono Pro v3 CSV exports. Useful for lap analysis, custom telemetry processing, or integration with motorsport data tools.

## 📦 Install

```bash
dotnet add package RaceChronoSharp
```
Or via the NuGet Package Manager:
```bash
Install-Package RaceChronoSharp
```
## 🚀 Usage
```csharp
using RaceChronoSharp;

string csvPath = "path/to/session.csv";
RaceChronoSession session = RaceChronoParser.Parse(csvPath);

foreach (RaceChronoDataPoint? point  in session.DataPoints)
{
    double speedKmh = (point.Speed ?? 0) * 3.6; // peed in km/h
    Console.WriteLine($"Lap: {point.LapNumber}, Timestamp: {point.Timestamp}, Latitude: {point.Latitude}, 
        Longitude: {point.Longitude},Speed: {speedKmh:F2} km/h");
}
```

## 📜 License
This project is licensed under the MIT License. See the LICENSE file for details.