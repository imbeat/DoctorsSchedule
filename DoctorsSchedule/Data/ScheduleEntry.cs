using System;
using System.Diagnostics;

namespace DoctorsSchedule.Data
{
    /// <summary>
    /// Запись на прием
    /// </summary>
    [DebuggerDisplay("Прием: {Patient} {StartTime} - {FinishTime}")]
    public class ScheduleEntry
    {
        /// <summary>
        /// Фио пациента
        /// </summary>
        public string Patient { get; set; }

        /// <summary>
        /// Время начала приема
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Длительность приема
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Время окончания приема
        /// </summary>
        public TimeSpan FinishTime
        {
            get { return StartTime.Add(Duration); }
        }

        public ScheduleEntry(string patient, TimeSpan startTime, int durationInMinutes)
            : this(patient, startTime, new TimeSpan(0, durationInMinutes, 0))
        {
        }

        public ScheduleEntry(string patient, TimeSpan startTime, TimeSpan duration)
        {
            if (string.IsNullOrWhiteSpace(patient)) throw new ArgumentNullException("patient");
            if (startTime.TotalDays > 1d)
            {
                throw new ArgumentOutOfRangeException("startTime");
            }
            if (duration.TotalMinutes > 60d)
            {
                throw new ArgumentOutOfRangeException("duration");
            }
            if (duration.Minutes%5 != 0)
            {
                throw new ArgumentException("Длительность приема должна быть кратна 5 минутам");
            }
            Patient = patient;
            StartTime = startTime;
            Duration = duration;
        }

        /// <summary>
        /// Проверяет, что приемы пересекаются по времени
        /// </summary>
        public static bool CheckIntersection(ScheduleEntry entry1, ScheduleEntry entry2)
        {
            var minStartTimeEntry = entry1;
            var maxStartTimeEntry = entry2;
            if (entry2.StartTime < entry1.StartTime)
            {
                minStartTimeEntry = entry2;
                maxStartTimeEntry = entry1;
            }

            return minStartTimeEntry.StartTime.Add(minStartTimeEntry.Duration) > maxStartTimeEntry.StartTime;
        }
    }
}