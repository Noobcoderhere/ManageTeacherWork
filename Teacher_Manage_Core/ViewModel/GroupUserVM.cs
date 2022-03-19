using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.Person;

namespace Teacher_Manage_Core.ViewModel
{
    public class GroupUserVM
    {
        public GroupUserVM()
        {
            Users = new HashSet<UserVM>();
        }

        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(255)]
        public string Name_GroupUser { get; set; }

        [StringLength(10)]
        public string CodeRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserVM> Users { get; set; }
    }
}
