using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.WorkRepo
{
    public class WorkRepository : GenericRepository<Work>, IWorkRepository
    {
        private readonly MTWDbContext _context;

        public WorkRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
