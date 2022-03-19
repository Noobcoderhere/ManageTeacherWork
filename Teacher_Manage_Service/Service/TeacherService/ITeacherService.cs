using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.Person;

namespace Teacher_Manage_Service.Service.TeacherService
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherVM>> GetTeachers(bool allowTracking = true);
        TeacherVM GetTeacherById(int id);
        bool AddTeacher(TeacherVM teacherVM);
        bool UpdateTeacher(TeacherVM teacherVM);
        bool DeleteTeacher(int id);
        Task<IEnumerable<TeacherVM>> GetTeachersByCondition(Expression<Func<Teacher, bool>> predicate, bool allowTracking = true);
    }
}
