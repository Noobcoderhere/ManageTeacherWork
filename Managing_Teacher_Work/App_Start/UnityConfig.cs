using AutoMapper;
using System.Web.Mvc;
using Teacher_Manage_Repository.Contract;
using Teacher_Manage_Repository.Repository.ClassRepo;
using Teacher_Manage_Repository.Repository.EventRepo;
using Teacher_Manage_Repository.Repository.FileRepo;
using Teacher_Manage_Repository.Repository.GroupUserRepo;
using Teacher_Manage_Repository.Repository.MajorRepo;
using Teacher_Manage_Repository.Repository.MonthReportRepo;
using Teacher_Manage_Repository.Repository.StudentRepo;
using Teacher_Manage_Repository.Repository.TeachCalendarRepo;
using Teacher_Manage_Repository.Repository.TeacherRepo;
using Teacher_Manage_Repository.Repository.UnitOfWork;
using Teacher_Manage_Repository.Repository.UserRepo;
using Teacher_Manage_Repository.Repository.WorkingCalendarRepo;
using Teacher_Manage_Repository.Repository.WorkRepo;
using Teacher_Manage_Service.Service.ClassService;
using Teacher_Manage_Service.Service.EventService;
using Teacher_Manage_Service.Service.FileService;
using Teacher_Manage_Service.Service.MajorService;
using Teacher_Manage_Service.Service.ReportService;
using Teacher_Manage_Service.Service.RoleService;
using Teacher_Manage_Service.Service.StudentService;
using Teacher_Manage_Service.Service.TeachCalendarService;
using Teacher_Manage_Service.Service.TeacherService;
using Teacher_Manage_Service.Service.UserService;
using Teacher_Manage_Service.Service.WorkingCalendarService;
using Teacher_Manage_Service.Service.WorkService;
using Unity;
using Unity.Mvc5;

namespace Managing_Teacher_Work
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            IMapper mapper = configuration.CreateMapper();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterInstance(mapper);
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IWorkingCalendarRepository, WorkingCalendarRepository>();
            container.RegisterType<IClassRepository, ClassRepository>();
            container.RegisterType<IEventRepository, EventRepository>();
            container.RegisterType<IMonthReportRepository, MonthReportRepository>();
            container.RegisterType<IMajorRepository, MajorRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<ITeacherRepository, TeacherRepository>();
            container.RegisterType<IWorkRepository, WorkRepository>();
            container.RegisterType<IGroupUserRepository, GroupUserRepository>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IWorkService, WorkService>();
            container.RegisterType<ITeacherService, TeacherService>();
            container.RegisterType<IWorkingCalendarService, WorkingCalendarService>();
            container.RegisterType<IMajorService, MajorService>();
            container.RegisterType<IClassService, ClassService>();
            container.RegisterType<IEventService, EventService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IFileRepository, FileRepository>();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<ITeachCalendarRepository, TeachCalendarRepository>();
            container.RegisterType<ITeachCalendarService, TeachCalendarService>();

            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}