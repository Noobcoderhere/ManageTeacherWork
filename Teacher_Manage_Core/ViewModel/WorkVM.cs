using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teacher_Manage_Core.ViewModel
{
    public class WorkVM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkVM()
        {
            CalendarWorkings = new HashSet<CalendarWorking>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Name_Work { get; set; }

        [StringLength(255)]
        public string Description_Work { get; set; }

        [StringLength(255)]
        public string Details_Work { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalendarWorking> CalendarWorkings { get; set; }
    }
}
