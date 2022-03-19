using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Manage_Core.ViewModel
{
    public class TeachCalendarVM
    {
        public int ID { get; set; }
        public string Subject_Name { get; set; }
        public string Room { get; set; }
        public int TeacherID { get; set; }
        public int ClassID { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string TeacherName { get; set; }
        public string ClassName { get; set; }

        public virtual Class Class { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
