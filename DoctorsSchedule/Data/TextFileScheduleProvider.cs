using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace DoctorsSchedule.Data
{
    /// <summary>
    /// Провайдер данных о расписании приемов из текстового файла
    /// </summary>
    public class TextFileScheduleProvider : IScheduleProvider
    {
        private const string FileName = "TestData.txt";

        public List<ScheduleEntry> Get()
        {
            var path = HostingEnvironment.MapPath(@"~/App_Data/" + FileName);
            var lines = File.ReadLines(path);
            return lines.Select(x =>
                    {
                        if (string.IsNullOrWhiteSpace(x))
                        {
                            return null;
                        }
                        var parts = x.Split(';');

                        var patient = parts[0];
                        var time = TimeSpan.ParseExact(parts[1], "hh':'mm", CultureInfo.CurrentCulture);
                        var duration = int.Parse(parts[2]);
                        return new ScheduleEntry(patient, time, duration);
                    })
                .Where(x => x != null)
                .ToList();
        }
    }
}