using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Security.AccessControl;

namespace DoctorsSchedule.Models
{
    /// <summary>
    /// Модель представления расписания приемов
    /// </summary>
    public class ScheduleViewModel
    {
        /// <summary>
        /// Список записей пациентов к врачам ("внешний" список - колонки таблицы, "вложенный" список - приемы в колонках)
        /// </summary>
        public List<List<ScheduleEntryViewModel>> ScheduleItems { get; set; }

        /// <summary>
        /// Время начала рабочего дня
        /// </summary>
        public TimeSpan DayStartTime { get; private set; }

        /// <summary>
        /// Время окончания рабочего дня
        /// </summary>
        public TimeSpan DayFinishTime { get; private set; }

        public ScheduleViewModel()
        {
            // время начала и окончания рабочего дня берем из конфигурации (см файл web.config)
            var dayStartTimeStr = ConfigurationManager.AppSettings["DayStartTime"];
            var dayFinishTimeStr = ConfigurationManager.AppSettings["DayFinishTime"];

            DayStartTime = TimeSpan.ParseExact(dayStartTimeStr, "hh':'mm", CultureInfo.CurrentCulture);
            DayFinishTime = TimeSpan.ParseExact(dayFinishTimeStr, "hh':'mm", CultureInfo.CurrentCulture);
        }
    }
}