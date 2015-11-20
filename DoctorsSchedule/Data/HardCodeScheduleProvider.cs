using System.Collections.Generic;
using System.Linq;
using DoctorsSchedule.App_Data;

namespace DoctorsSchedule.Data
{
    /// <summary>
    /// Провайдер тестовых данных о приемах, захардкоженных в статик классе
    /// </summary>
    public class HardCodeScheduleProvider : IScheduleProvider
    {
        /// <summary>
        /// Возвращает список записей на приемы, отсортированный по возрастанию времени начала приема
        /// </summary>
        public List<ScheduleEntry> Get()
        {
            return TestScheduleData.Schedule.OrderBy(x => x.StartTime).ToList();
        }
    }
}