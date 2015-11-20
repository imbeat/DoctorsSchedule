using System;

namespace DoctorsSchedule.Models
{
    /// <summary>
    /// ������� ���������� (������ �������� � �����)
    /// </summary>
    public class ScheduleEntryViewModel
    {
        /// <summary>
        /// ��� �������� (���� ���� �����)
        /// </summary>
        public string Patient { get; set; }

        /// <summary>
        /// ����� ������ ������
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// ������������ ������
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// ����� ��������� ������
        /// </summary>
        public TimeSpan FinishTime
        {
            get { return StartTime.Add(Duration); }
        }

        /// <summary>
        /// ���������� ������� ����� � ������� ���� ���������� � ���� ������
        /// </summary>
        public int ColumnSpanFactor
        {
            get { return (int) (Duration.TotalMinutes/TimeInterval.TotalMinutes); }
        }

        /// <summary>
        /// ��������� ��������� �� �������� ����� <paramref name="time"/> � ���������� ����� ������� � ���������� ������
        /// </summary>
        /// <param name="time"></param>
        public bool Contains(TimeSpan time)
        {
            return StartTime <= time && FinishTime > time;
        }

        /// <summary>
        /// ����������� ��������� �������� ��� ���������� � ������� (5 �����)
        /// </summary>   
        public const int TimeIntervalInMinutes = 5;

        /// <summary>
        /// ����������� ��������� �������� ��� ����������
        /// </summary>
        public static readonly TimeSpan TimeInterval = new TimeSpan(0, TimeIntervalInMinutes, 0);
    }
}