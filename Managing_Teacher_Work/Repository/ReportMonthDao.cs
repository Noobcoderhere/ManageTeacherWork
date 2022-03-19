using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class ReportMonthDao
    {
        MTWDbContext db = null;

        public ReportMonthDao()
        {
            db = new MTWDbContext();
        }
       
        public List<MonthReport> ListAll()
        {
            return db.MonthReports.ToList();
        }
        public List<MonthReport>ListWithItem(int top)
        {
            return db.MonthReports.Where(x => x.ID > 0).OrderByDescending(y => y.CreatedDate).Take(top).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Files.Find(id);
                db.Files.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteReport(int id)
        {
            try
            {
                var rp = db.MonthReports.Find(id);
                db.MonthReports.Remove(rp);
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