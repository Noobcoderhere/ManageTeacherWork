using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teacher_Manage_Core;
using PagedList;


namespace Managing_Teacher_Work.DAO
{
    public class ScienseDao
    {
        MTWDbContext db = null;

        public ScienseDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Major> Listpg(int page, int pageSize)
        {
            return db.Majors.OrderByDescending(x => x.CreatedDate ).ToPagedList(page, pageSize);
        }
        public List<Major> ListAll()
        {
            return db.Majors.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Majors.Find(id);
                db.Majors.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Major GetScienceById(long id)
        {
            return db.Majors.Find(id);
        }
    }
}