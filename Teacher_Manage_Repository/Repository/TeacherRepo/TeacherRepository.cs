using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.TeacherRepo
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly MTWDbContext _context;

        public TeacherRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
