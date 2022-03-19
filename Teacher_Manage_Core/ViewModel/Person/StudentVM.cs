using System;
using System.ComponentModel.DataAnnotations;

namespace Teacher_Manage_Core.ViewModel.Person
{
    public class StudentVM
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name_Student { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public int ClassID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Class Class { get; set; }

        public string ClassName { get; set; }
    }
}
