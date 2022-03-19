using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Teacher_Manage_Core.ViewModel.WorkingCalendar
{
    public class WorkingCalendarVM
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name_CalendarWorking { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int TeacherID { get; set; }

        public int WorkID { get; set; }

        public int TypeCalendarID { get; set; }

        [StringLength(255)]
        public string WorkState { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Files { get; set; }

        public virtual TypeCalendar TypeCalendar { get; set; }

        public virtual Work Work { get; set; }
        public string Teacher_Name { get; set; }
        public string Work_Name { get; set; }
        public string TypeCalendar_Name { get; set; }

    }
}
