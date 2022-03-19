using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.MajorRepo
{
    public class MajorRepository : GenericRepository<Major>, IMajorRepository
    {
        private readonly MTWDbContext _context;

        public MajorRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
