using System;

namespace DoctorsSchedule.Models
{
    /// <summary>
    /// Элемент расписания (запись пациента к врачу)
    /// </summary>
    public class ScheduleEntryViewModel
    {
        /// <summary>
        /// ФИО пациента (если есть прием)
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

        /// <summary>
        /// Отображает сколько строк в таблице надо объединять в одну ячейку
        /// </summary>
        public int ColumnSpanFactor
        {
            get { return (int) (Duration.TotalMinutes/TimeInterval.TotalMinutes); }
        }

        /// <summary>
        /// Проверяет находится ли заданное время <paramref name="time"/> в промежутке между началом и окончанием приема
        /// </summary>
        /// <param name="time"></param>
        public bool Contains(TimeSpan time)
        {
            return StartTime <= time && FinishTime > time;
        }

        /// <summary>
        /// Минимальный временной интервал для расписания в минутах (5 минут)
        /// </summary>   
        public const int TimeIntervalInMinutes = 5;

        /// <summary>
        /// Минимальный временной интервал для расписания
        /// </summary>
        public static readonly TimeSpan TimeInterval = new TimeSpan(0, TimeIntervalInMinutes, 0);
    }
}