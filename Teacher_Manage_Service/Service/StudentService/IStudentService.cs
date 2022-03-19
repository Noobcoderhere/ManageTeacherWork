using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.Person;

namespace Teacher_Manage_Service.Service.StudentService
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentVM>> GetStudents(bool allowTraacking = true);
        Task<IEnumerable<StudentVM>> GetStudentsByCondition(Expression<Func<Student,bool>> predicate, bool allowTracking = true);
        StudentVM GetStudentById(int id);
        bool AddStudent(StudentVM studentVM);
        bool DeleteStudent(int id);
        bool UpdateStudent(StudentVM studentVM);
    }
}
