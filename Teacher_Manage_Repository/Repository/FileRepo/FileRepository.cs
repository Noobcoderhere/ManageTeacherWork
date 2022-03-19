using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.FileRepo
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        private readonly MTWDbContext _context;

        public FileRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
