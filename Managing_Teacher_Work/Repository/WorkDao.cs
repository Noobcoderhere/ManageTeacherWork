
using Teacher_Manage_Core;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class WorkDao
    {
        MTWDbContext db = null;

        public WorkDao()
        {
            db = new MTWDbContext();
        }
   
        public List<Work> ListAll()
        {
            return db.Works.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Works.Find(id);
                db.Works.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Work ViewDetailsWork(long id)
        {
            return db.Works.Find(id);
        }
    }
}