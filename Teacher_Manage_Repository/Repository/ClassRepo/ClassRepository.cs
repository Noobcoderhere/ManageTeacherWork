using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.ClassRepo
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly MTWDbContext _context;

        public ClassRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
