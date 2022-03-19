using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Managing_Teacher_Work
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
 name: "Thông tin sinh viên",
 url: "Profile-Student/{id}",
 defaults: new { controller = "Frontend", action = "ProfileStudent", id = UrlParameter.Optional },
 namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
name: "Thống kê báo cáo",
url: "Statistics-Report",
defaults: new { controller = "ReportMonth", action = "Statistics_Report", id = UrlParameter.Optional },
namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
 name: "Báo cáo tháng",
 url: "Report",
 defaults: new { controller = "ReportMonth", action = "Index", id = UrlParameter.Optional },
 namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
  name: "Thông tin cá nhân",
  url: "Profile-Teacher/{id}",
  defaults: new { controller = "Frontend", action = "ProfileTeacher", id = UrlParameter.Optional },
  namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
  name: "Thông tin tài khoản",
  url: "Profile-User/{id}",
  defaults: new { controller = "Frontend", action = "ProfileUser", id = UrlParameter.Optional },
  namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Chi tiết lịch công tác cấp 2",
    url: "Calendar-Working-Detail-Level2/{id}",
    defaults: new { controller = "Home", action = "CalendarWorkingDetails_Level2", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
       name: "Danh sách sinh viên theo lớp",
       url: "StudentsInClass/{idClass}",
       defaults: new { controller = "Student", action = "GetListStudentInClass", idClass = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
      name: "Danh sách giáo viên theo khoa",
      url: "TeachersByMajor/{majorId}",
      defaults: new { controller = "Teacher", action = "GetTeacherByMajor", majorId = UrlParameter.Optional },
      namespaces: new[] { "Managing_Teacher_Work.Controllers" }
  );
            routes.MapRoute(
       name: "Danh sách lớp theo khoa",
       url: "ClassesByMajor/{majorId}",
       defaults: new { controller = "Class", action = "GetClassesByMajor", majorId = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
    name: "Nhật ký sự kiện",
    url: "Event",
    defaults: new { controller = "Event", action = "Index", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Ghi chú công việc",
    url: "Make-Notes",
    defaults: new { controller = "Event", action = "CalendarNote", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Chi tiết lịch công tác",
    url: "Calendar-Working-Detail/{id}",
    defaults: new { controller = "Home", action = "CalendarWorkingDetails", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
   name: "Danh sách khoa",
   url: "MajorList",
   defaults: new { controller = "Major", action = "GetMajorList", id = UrlParameter.Optional },
   namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Danh sách lớp học",
    url: "ClassList",
    defaults: new { controller = "Class", action = "GetClassList", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
     name: "Trang chủ",
     url: "Home",
     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
     namespaces: new[] { "Managing_Teacher_Work.Controllers" }
 );
            routes.MapRoute(
      name: "Đăng xuất",
      url: "Logout-System",
      defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional },
      namespaces: new[] { "Managing_Teacher_Work.Controllers" }
  );
            routes.MapRoute(
       name: "Đăng nhập",
       url: "Login-system",
       defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
       name: "Quản lý lịch công tác",
       url: "CalendarWorkingManagement",
       defaults: new { controller = "CalendarWorking", action = "Index", id = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
        name: "Quản lý sinh viên",
        url: "StudentManagement",
        defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "Managing_Teacher_Work.Controllers" }
    );
            routes.MapRoute(
        name: "Quản lý loại công việc",
        url: "TypeCalendarManagement",
        defaults: new { controller = "TypeCalendar", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "Managing_Teacher_Work.Controllers" }
    );
            routes.MapRoute(
         name: "Quản lý lớp học",
         url: "ClassManagement",
         defaults: new { controller = "Class", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "Managing_Teacher_Work.Controllers" }
     );
            routes.MapRoute(
           name: "Quản lý người dùng",
           url: "UserManagement",
           defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "Managing_Teacher_Work.Controllers" }
       );
            routes.MapRoute(
             name: "Quản lý giáo viên",
             url: "TeacherManagement",
             defaults: new { controller = "Teacher", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "Managing_Teacher_Work.Controllers" }
         );
            routes.MapRoute(
                name: "Quan ly khoa ",
                url: "MajorManagement",
                defaults: new { controller = "Major", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Managing_Teacher_Work.Controllers" }
            );
            routes.MapRoute(
                name: "Quan ly công việc ",
                url: "WorkManagement",
                defaults: new { controller = "Work", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Managing_Teacher_Work.Controllers" }
            );
            routes.MapRoute(
                name: "Quản lý lịch giảng dạy",
                url: "TeachCalendar-Management",
                defaults: new { controller = "TeachCalendar", action = "ManageTeachCalendar", id = UrlParameter.Optional },
                namespaces: new[] { "Managing_Teacher_Work.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Managing_Teacher_Work.Controllers" }
            );

        }
    }
}
