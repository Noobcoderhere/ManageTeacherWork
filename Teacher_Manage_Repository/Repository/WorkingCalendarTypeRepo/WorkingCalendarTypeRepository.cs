using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.WorkingCalendarTypeRepo
{
    public class WorkingCalendarTypeRepository : GenericRepository<TypeCalendar>, IWorkingCalendarTypeRepository
    {
        private readonly MTWDbContext _context;

        public WorkingCalendarTypeRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
