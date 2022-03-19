using Teacher_Manage_Core;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class TypeCalendarDao
    {

        MTWDbContext db = null;

        public TypeCalendarDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<TypeCalendar> Listpg(int page, int pageSize)
        {
            return db.TypeCalendars.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<TypeCalendar> ListAll()
        {
            return db.TypeCalendars.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.TypeCalendars.Find(id);
                db.TypeCalendars.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public TypeCalendar ViewDetailTypeCalendar(long id)
        {
            return db.TypeCalendars.Find(id);
        }
    }
}