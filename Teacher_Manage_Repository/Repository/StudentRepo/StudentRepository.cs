using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Repository.Repository.GenericRepo;

namespace Teacher_Manage_Repository.Repository.StudentRepo
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository 
    {
        private readonly MTWDbContext _context;

        public StudentRepository(MTWDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
