using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorsSchedule.Data;
using DoctorsSchedule.Models;

namespace DoctorsSchedule.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Поставщик данных о списке приемов
        /// </summary>
        private readonly IScheduleProvider _scheduleProvider;

        public HomeController()
        {
            _scheduleProvider = new HardCodeScheduleProvider();
        }

        public ActionResult Index()
        {
            var scheduleEntries = _scheduleProvider.Get();

            var scheduleItems = new List<List<ScheduleEntryViewModel>>();

            foreach (var current in scheduleEntries)
            {
                // ищем первый попавшийся столбец расписания, в котором время окончания последнего приема не больше, чем время начала текущего
                // предполагаем что следующий прием может начаться в тот же момент, в который закончился предыдущий
                var columnForCurrentEntry = scheduleItems.FirstOrDefault(x => x.Last().FinishTime <= current.StartTime);
                if (columnForCurrentEntry == null)
                {
                    // если не нашли то добавляем новый столбец в таблицу расписания
                    columnForCurrentEntry = new List<ScheduleEntryViewModel>();
                    scheduleItems.Add(columnForCurrentEntry);
                }
                var scheduleEntryViewModel = new ScheduleEntryViewModel()
                {
                    Duration = current.Duration,
                    StartTime = current.StartTime,
                    Patient = current.Patient,
                };
                columnForCurrentEntry.Add(scheduleEntryViewModel);
            }

            var model = new ScheduleViewModel
            {
                ScheduleItems = scheduleItems
            };
            return View(model);
        }
    }
}