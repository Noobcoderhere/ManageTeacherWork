using Teacher_Manage_Core;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class TeacherDao
    {
        MTWDbContext db = null;

        public TeacherDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Teacher> Listpg(int page, int pageSize)
        {
            return db.Teachers.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Teacher> ListAll()
        {
            return db.Teachers.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Teachers.Find(id);
                db.Teachers.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Teacher ViewDetails(long id)
        {
            return db.Teachers.Find(id);
        }
        public List<Teacher> GetListTeacherByScienceID(long idScience)
        {
            return db.Teachers.Where(x => x.MajorID == idScience).OrderByDescending(y => y.CreatedDate).ToList();
        }
    }
}