using System.Threading.Tasks;
using Teacher_Manage_Core;
using Teacher_Manage_Repository.Contract;
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

namespace Teacher_Manage_Repository.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MTWDbContext _context;
        private IWorkingCalendarRepository _workingCalendarRepository;
        private IWorkingCalendarTypeRepository _workingCalendarTypeRepository;
        private IClassRepository _classRepository;
        private IEventRepository _eventRepository;
        private IMonthReportRepository _monthReportRepository;
        private IMajorRepository _majorRepository;
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;
        private IUserRepository _userRepository;
        private IWorkRepository _workRepository;
        private IFileRepository _fileRepository;
        private ITeachCalendarRepository _teachCalendarRepository;

        public UnitOfWork(MTWDbContext context)
        {
            _context = context;
        }

        public IWorkingCalendarRepository WorkingCalendar => _workingCalendarRepository ?? new WorkingCalendarRepository(_context);

        public IClassRepository Class => _classRepository ?? new ClassRepository(_context);

        public IEventRepository Event => _eventRepository ?? new EventRepository(_context);

        public IMonthReportRepository MonthReport => _monthReportRepository ?? new MonthReportRepository(_context);

        public IMajorRepository Major => _majorRepository ?? new MajorRepository(_context);

        public IStudentRepository Student => _studentRepository ?? new StudentRepository(_context);

        public ITeacherRepository Teacher => _teacherRepository ?? new TeacherRepository(_context);

        public IUserRepository User => _userRepository ?? new UserRepository(_context);

        public IWorkRepository Work => _workRepository ?? new WorkRepository(_context);

        public IWorkingCalendarTypeRepository WorkingCalendarType => _workingCalendarTypeRepository ?? new WorkingCalendarTypeRepository(_context);

        public IFileRepository File => _fileRepository ?? new FileRepository(_context);

        public ITeachCalendarRepository TeachCalendar => _teachCalendarRepository ?? new TeachCalendarRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
