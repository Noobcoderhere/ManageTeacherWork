using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.GroupUserRepo
{
    public class GroupUserRepository : GenericRepository<GroupUser>, IGroupUserRepository 
    {
        private readonly MTWDbContext _context;

        public GroupUserRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
