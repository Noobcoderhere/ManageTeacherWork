using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Core.ViewModel.Person;
using Teacher_Manage_Core.ViewModel.WorkingCalendar;

namespace Managing_Teacher_Work
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<User, UserVM>();
            CreateMap<UserVM, User>();
            CreateMap<GroupUser, GroupUserVM>();
            CreateMap<Work, WorkVM>();
            CreateMap<WorkVM, Work>();
            CreateMap<Teacher, TeacherVM>();
            CreateMap<TeacherVM, Teacher>();
            CreateMap<WorkingCalendarVM, CalendarWorking>();
            CreateMap<CalendarWorking, WorkingCalendarVM>();
            CreateMap<TypeCalendar, CalendarTypeVM>();
            CreateMap<CalendarTypeVM, TypeCalendar>();
            CreateMap<Major, MajorVM>();
            CreateMap<MajorVM, Major>();
            CreateMap<Class, ClassVM>();
            CreateMap<ClassVM, Class>();
            CreateMap<EventVM, Event>();
            CreateMap<Event, EventVM>();
            CreateMap<Student, StudentVM>();
            CreateMap<StudentVM, Student>();
            CreateMap<ReportVM, MonthReport>();
            CreateMap<FileVM, File>();
            CreateMap<File, FileVM>();
            CreateMap<MonthReport, ReportVM>();
            CreateMap<TeachCalendar, TeachCalendarVM>();
            CreateMap<TeachCalendarVM, TeachCalendar>();
        }
    }
}