using System;
using System.ComponentModel.DataAnnotations;

namespace Teacher_Manage_Core.ViewModel
{
    public class EventVM
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [StringLength(10)]
        public string ThemeColor { get; set; }

        public bool IsFullDay { get; set; }
    }
}
