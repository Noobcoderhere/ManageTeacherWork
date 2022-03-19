using System;
using System.ComponentModel.DataAnnotations;

namespace Teacher_Manage_Core.ViewModel.Person
{
    public class UserVM
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupID { get; set; }

        public int? TeacherID { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual GroupUser GroupUser { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
