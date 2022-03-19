using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.TeachCalendarRepo
{
    public class TeachCalendarRepository : GenericRepository<TeachCalendar>, ITeachCalendarRepository
    {
        private readonly MTWDbContext _context;

        public TeachCalendarRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
