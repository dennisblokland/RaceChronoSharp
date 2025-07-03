using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace RaceChronoSharp
{
    public class RaceChronoSession
    {
        public RaceChronoSessionMetadata Metadata { get; set; } = new();
        public List<RaceChronoDataPoint> DataPoints { get; set; } = [];
        public static RaceChronoSession Parse(string path)
        {

            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
                IgnoreBlankLines = true
            };

            using StreamReader reader = new(path);
            using CsvReader csv = new(reader, config);

            // Skip metadata lines (assume 9)
            for (int i = 0; i < 9; i++) reader.ReadLine();

            // Read header and second header (units)
            csv.Read();
            csv.ReadHeader();
            csv.Read(); // Read the second header line (units)
            csv.Read(); // Skip units line
            csv.Context.RegisterClassMap<RaceChronoDataPointMap>();

            List<RaceChronoDataPoint> records = csv.GetRecords<RaceChronoDataPoint>().ToList();
            return new RaceChronoSession
            {
                Metadata = ReadRaceChronoMetadata(reader),
                DataPoints = records
            };
        }

        public static RaceChronoSessionMetadata ReadRaceChronoMetadata(StreamReader reader)
        {
            RaceChronoSessionMetadata metadata = new();

            while (reader.Peek() > -1)
            {
                string? line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("timestamp"))
                    break;

                string[] parts = line.Split(',', 3); // include room for Created time

                string key = parts[0].Trim();
                string value = parts.Length > 1 ? parts[1].Trim('"') : "";

                switch (key)
                {
                    case "Format":
                        metadata.Format = value;
                        break;
                    case "Session title":
                        metadata.SessionTitle = value;
                        break;
                    case "Session type":
                        metadata.SessionType = value;
                        break;
                    case "Track name":
                        metadata.TrackName = value;
                        break;
                    case "Driver name":
                        metadata.DriverName = value;
                        break;
                    case "Created":
                        if (DateTime.TryParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                        {
                            string? timeStr = parts.Length > 2 ? parts[2].Trim('"') : null;
                            if (TimeSpan.TryParse(timeStr, out TimeSpan time))
                                metadata.Created = date.Add(time);
                            else
                                metadata.Created = date;
                        }
                        break;
                    case "Note":
                        metadata.Note = value;
                        break;
                }
            }

            return metadata;
        }
        public static string[] RenameDuplicateHeaders(string[] headers)
        {
            Dictionary<string, int> seen = new();
            string[] result = new string[headers.Length];

            for (int i = 0; i < headers.Length; i++)
            {
                string header = headers[i];
                if (string.IsNullOrWhiteSpace(header))
                {
                    result[i] = $"unnamed{i}";
                    continue;
                }

                if (seen.TryGetValue(header, out int count))
                {
                    count++;
                    seen[header] = count;
                    result[i] = $"{header}_{count}";
                }
                else
                {
                    seen[header] = 1;
                    result[i] = header;
                }
            }

            return result;
        }

    }
}