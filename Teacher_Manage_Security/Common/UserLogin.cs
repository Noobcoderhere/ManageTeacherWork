using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Web.Common
{
    [Serializable]
    public class UserLogin
    {
        public int ID { set; get; }
        public int TeacherID { get; set; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string GroupID { set; get; }
    }
}