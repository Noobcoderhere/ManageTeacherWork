using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập UserName")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập Password")]
        public string PassWord { set; get; }
    }
}