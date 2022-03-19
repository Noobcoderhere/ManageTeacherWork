using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.TeachCalendarService
{
    public interface ITeachCalendarService
    {
        IEnumerable<TeachCalendarVM> GetTeachCalendars(int? teacherID = null, bool allowTracking = true);
        IEnumerable<TeachCalendarVM> GetTeachCalendarsByCondition(Expression<Func<TeachCalendar, bool>> predicate, bool allowTracking = true);
        TeachCalendarVM GetTeachCalendarByCondition(Expression<Func<TeachCalendar, bool>> predicate, bool allowTracking = true);
        TeachCalendarVM GetTeachCalendarById(int id);
        bool Cancel(int id);
        bool AddTeachCalendar(TeachCalendarVM teachCalendarVM);
        bool UpdateTeachCalendar(TeachCalendarVM teachCalendarVM);
        bool DeleteTeachCalendar(int id);

        //IEnumerable<TeachCalendarVM>
    }
}
