using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.MonthReportRepo
{
    public class MonthReportRepository : GenericRepository<MonthReport>, IMonthReportRepository
    {
        private readonly MTWDbContext _context;

        public MonthReportRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
