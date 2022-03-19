using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.UserRepo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly MTWDbContext _context;

        public UserRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
