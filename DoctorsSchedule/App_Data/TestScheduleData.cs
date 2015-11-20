using System;
using System.Collections.Generic;
using DoctorsSchedule.Data;

namespace DoctorsSchedule.App_Data
{
    /// <summary>
    /// Тестовые данные для расписания приемов
    /// </summary>
    public static class TestScheduleData
    {
        /// <summary>
        /// Список приемов к врачам
        /// </summary>
         public static List<ScheduleEntry> Schedule = new List<ScheduleEntry>
         {
             new ScheduleEntry("Иванов И.И.", new TimeSpan(10,0,0), 15),
             new ScheduleEntry("Петров П.П.", new TimeSpan(10,10,0), 30),
             new ScheduleEntry("Сидоров С.С.", new TimeSpan(10,20,0), 15),
             new ScheduleEntry("Тестов Т.Т.", new TimeSpan(10,25,0), 45),
             new ScheduleEntry("Тестов2 Т.Т.", new TimeSpan(11,35,0), 60),
             new ScheduleEntry("Кудряшов Д.Р.", new TimeSpan(11,0,0), 20),
             new ScheduleEntry("Конышев А.А.", new TimeSpan(11,25,0), 25),
             new ScheduleEntry("Конышев2 А.А.", new TimeSpan(11,50,0), 25),
             new ScheduleEntry("Дрындулетов Д.Д", new TimeSpan(11, 30,0), 45),
         };
    }
}