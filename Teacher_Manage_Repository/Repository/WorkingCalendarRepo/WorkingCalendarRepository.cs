using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.WorkingCalendarRepo
{
    public class WorkingCalendarRepository : GenericRepository<CalendarWorking>, IWorkingCalendarRepository
    {
        private readonly MTWDbContext _context;

        public WorkingCalendarRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
