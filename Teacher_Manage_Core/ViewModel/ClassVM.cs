using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teacher_Manage_Core.ViewModel
{
    public class ClassVM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassVM()
        {
            Students = new HashSet<Student>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int TeacherID { get; set; }

        public int MajorID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Major Major { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
        public string TeacherName { get; set; }
        public string MajorName { get; set; }
        public string HavingClass { get; set; }
    }
}
