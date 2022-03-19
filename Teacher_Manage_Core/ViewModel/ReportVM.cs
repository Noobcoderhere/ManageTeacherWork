using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Manage_Core.ViewModel
{
    public class ReportVM
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ClassName { get; set; }

        public DateTime Date { get; set; }

        public string Files { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
