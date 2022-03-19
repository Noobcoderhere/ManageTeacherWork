using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.EventRepo
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly MTWDbContext _context;

        public EventRepository(MTWDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
