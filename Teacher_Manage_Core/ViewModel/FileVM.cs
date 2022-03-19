using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Manage_Core.ViewModel
{
    public class FileVM
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string FileForm { get; set; }
    }
}
