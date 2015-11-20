using System.Collections.Generic;

namespace DoctorsSchedule.Data
{
    /// <summary>
    /// Провайдер данных о расписании приемов
    /// </summary>
    public interface IScheduleProvider
    {
        /// <summary>
        /// Возвращает список записей на приемы
        /// </summary>
        List<ScheduleEntry> Get();
    }
}