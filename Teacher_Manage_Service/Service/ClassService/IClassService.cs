using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teacher_Manage_Core;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.ClassService
{
    public interface IClassService
    {
        Task<IEnumerable<ClassVM>> GetClasses(bool allowTracking = true);
        Task<IEnumerable<ClassVM>> GetClassesByCondition(Expression<Func<Class,bool>> predicate, bool allowTracking = true);
        ClassVM GetClassById(int id);
        bool AddClass(ClassVM classVM);
        bool DeleteClass(int id);
        bool UpdateClass(ClassVM classVM);

    }
}
