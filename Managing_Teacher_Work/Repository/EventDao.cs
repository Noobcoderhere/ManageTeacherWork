using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class EventDao
    {
        MTWDbContext db = null;

        public EventDao()
        {
            db = new MTWDbContext();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Events.Find(id);
                db.Events.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}