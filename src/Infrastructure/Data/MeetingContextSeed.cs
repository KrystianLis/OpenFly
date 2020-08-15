﻿using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MeetingContextSeed
    {
        public static async Task SeedAsync(MeetingContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.MeetingTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/Types.json");
                    var types = JsonSerializer.Deserialize<List<MeetingType>>(typesData);

                    foreach (var item in types)
                    {
                        context.MeetingTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Meetings.Any())
                {
                    var meetingType = File.ReadAllText("../Infrastructure/Data/SeedData/Meetings.json");
                    var meetings = JsonSerializer.Deserialize<List<Meeting>>(meetingType);

                    foreach (var item in meetings)
                    {
                        context.Meetings.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<MeetingContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}