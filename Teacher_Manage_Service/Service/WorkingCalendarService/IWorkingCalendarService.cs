using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Teacher_Manage_Core;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Core.ViewModel.WorkingCalendar;

namespace Teacher_Manage_Service.Service.WorkingCalendarService
{
    public interface IWorkingCalendarService
    {
        Task<IEnumerable<WorkingCalendarVM>> GetWorkingCalendars(bool allowTracking = true);
        WorkingCalendarVM GetWorkingCalendarById(int id);
        WorkingCalendarVM GetWorkingCalendarByCondition(Expression<Func<CalendarWorking,bool>> predicate, bool allowTracking = true);
        bool AddWorkingCalendar(WorkingCalendarVM workingCalendar);
        bool UpdateWorkingCalendar(WorkingCalendarVM workingCalendar);
        bool DeleteWorkingCalendar(int id);
        bool Completed(int id);
        bool Cancel(int id);
        bool Continue(int id);

        Task<IEnumerable<CalendarTypeVM>> GetCalendarTypes(bool allowTracking = true);
        CalendarTypeVM GetCalendarTypeById(int id);
        bool AddCalendarType(CalendarTypeVM calendarTypeVM);
        bool DeleteCalendarType(int id);
        bool UpdateCalendarType(CalendarTypeVM calendarTypeVM);
    }
}
