using System;
using System.Threading.Tasks;
using Teacher_Manage_Repository.Repository.ClassRepo;
using Teacher_Manage_Repository.Repository.EventRepo;
using Teacher_Manage_Repository.Repository.FileRepo;
using Teacher_Manage_Repository.Repository.MajorRepo;
using Teacher_Manage_Repository.Repository.MonthReportRepo;
using Teacher_Manage_Repository.Repository.StudentRepo;
using Teacher_Manage_Repository.Repository.TeachCalendarRepo;
using Teacher_Manage_Repository.Repository.TeacherRepo;
using Teacher_Manage_Repository.Repository.UserRepo;
using Teacher_Manage_Repository.Repository.WorkingCalendarRepo;
using Teacher_Manage_Repository.Repository.WorkingCalendarTypeRepo;
using Teacher_Manage_Repository.Repository.WorkRepo;

namespace Teacher_Manage_Repository.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkingCalendarRepository WorkingCalendar { get; }
        IWorkingCalendarTypeRepository WorkingCalendarType { get; }
        IClassRepository Class { get; }
        IEventRepository Event { get; }
        IMonthReportRepository MonthReport { get; }
        IMajorRepository Major { get; }
        IStudentRepository Student { get; }
        ITeacherRepository Teacher { get; }
        IUserRepository User { get; }
        IWorkRepository Work { get; }
        IFileRepository File { get; } 
        ITeachCalendarRepository TeachCalendar { get; }
        Task<bool> SaveAsync();
        bool Save();
    }
}
