using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.TeachCalendarService
{
    public class TeachCalendarService : ITeachCalendarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeachCalendarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddTeachCalendar(TeachCalendarVM teachCalendarVM)
        {
            try
            {
                var teachCalendar = _mapper.Map<TeachCalendar>(teachCalendarVM);
                _unitOfWork.TeachCalendar.Add(teachCalendar);
                var check = _unitOfWork.Save();
                if(!check)
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool DeleteTeachCalendar(int id)
        {
            try
            {
                var teachCalendar = _unitOfWork.TeachCalendar.GetById(id);
                if(teachCalendar == null)
                {
                    return false;
                }
                _unitOfWork.TeachCalendar.Delete(teachCalendar);
                var check = _unitOfWork.Save();
                if(!check)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public TeachCalendarVM GetTeachCalendarByCondition(Expression<Func<TeachCalendar, bool>> predicate, bool allowTracking = true)
        {
            var teachCalendar = _unitOfWork.TeachCalendar.Get(predicate, allowTracking);
            var teachCalendarVM = _mapper.Map<TeachCalendarVM>(teachCalendar);
            teachCalendarVM.ClassName = _unitOfWork.Class.Get(x => x.ID == teachCalendar.ClassID, false).Name;
            teachCalendarVM.TeacherName = _unitOfWork.Teacher.Get(x => x.ID == teachCalendar.TeacherID, false).Name_Teacher;
            return teachCalendarVM;
        }

        public TeachCalendarVM GetTeachCalendarById(int id)
        {
            var teachCalendar = _unitOfWork.TeachCalendar.Get(x => x.ID == id);
            var teachCalendarVM = _mapper.Map<TeachCalendarVM>(teachCalendar);
            teachCalendarVM.ClassName = _unitOfWork.Class.Get(x => x.ID == teachCalendar.ClassID).Name;
            teachCalendarVM.TeacherName = _unitOfWork.Teacher.Get(x => x.ID == teachCalendar.TeacherID).Name_Teacher;
            return teachCalendarVM;
        }

        public IEnumerable<TeachCalendarVM> GetTeachCalendars(int? teacherID = null, bool allowTracking = true)
        {
            if(teacherID != null)
            {
                var teachCalendarsFiltered = _unitOfWork.TeachCalendar.GetMany(x => x.TeacherID == teacherID,allowTracking).ToList();
                for (int i = 0; i < teachCalendarsFiltered.Count(); i++)
                {
                    if(teachCalendarsFiltered[i].Status.Equals("TamHoan"))
                    {
                        goto skip;
                    }    
                    if (DateTime.Now.CompareTo(teachCalendarsFiltered[i].StartTime) >= 0 && DateTime.Now.CompareTo(teachCalendarsFiltered[i].EndTime) < 0)
                    {
                        teachCalendarsFiltered[i].Status = "DangDay";
                        _unitOfWork.TeachCalendar.Update(teachCalendarsFiltered[i]);
                    }
                    else if (DateTime.Now.CompareTo(teachCalendarsFiltered[i].EndTime) >= 0)
                    {
                        teachCalendarsFiltered[i].Status = "DaKetThuc";
                        _unitOfWork.TeachCalendar.Update(teachCalendarsFiltered[i]);
                    }
                    _unitOfWork.Save();
                    skip:
                    var teachCalendarVM = _mapper.Map<TeachCalendarVM>(teachCalendarsFiltered[i]);
                    teachCalendarVM.TeacherName = _unitOfWork.Teacher.GetById(teachCalendarsFiltered[i].TeacherID).Name_Teacher;
                    teachCalendarVM.ClassName = _unitOfWork.Class.GetById(teachCalendarsFiltered[i].ClassID).Name;
                    yield return teachCalendarVM;
                }
            }   
            else
            {
                var teachCalendars = _unitOfWork.TeachCalendar.GetAll(allowTracking).ToList();
                for (int i = 0; i < teachCalendars.Count(); i++)
                {
                    if(teachCalendars[i].Status.Equals("TamHoan"))
                    {
                        goto skip;
                    }    
                    if (DateTime.Now.CompareTo(teachCalendars[i].StartTime) >= 0 && DateTime.Now.CompareTo(teachCalendars[i].EndTime) < 0)
                    {
                        teachCalendars[i].Status = "DangDay";
                        _unitOfWork.TeachCalendar.Update(teachCalendars[i]);
                    }
                    else if (DateTime.Now.CompareTo(teachCalendars[i].EndTime) >= 0)
                    {
                        teachCalendars[i].Status = "DaKetThuc";
                        _unitOfWork.TeachCalendar.Update(teachCalendars[i]);
                    }
                    _unitOfWork.Save();
                    skip:
                    var teachCalendarVM = _mapper.Map<TeachCalendarVM>(teachCalendars[i]);
                    teachCalendarVM.TeacherName = _unitOfWork.Teacher.GetById(teachCalendars[i].TeacherID).Name_Teacher;
                    teachCalendarVM.ClassName = _unitOfWork.Class.GetById(teachCalendars[i].ClassID).Name;
                    yield return teachCalendarVM;
                }
            }    
        }

        public IEnumerable<TeachCalendarVM> GetTeachCalendarsByCondition(Expression<Func<TeachCalendar, bool>> predicate, bool allowTracking = true)
        {
            var teachCalendars = _unitOfWork.TeachCalendar.GetMany(predicate, allowTracking).ToList();
            for (int i = 0; i < teachCalendars.Count(); i++)
            {
                var teachCalendarVM = _mapper.Map<TeachCalendarVM>(teachCalendars[i]);
                teachCalendarVM.TeacherName = _unitOfWork.Teacher.GetById(teachCalendars[i].TeacherID).Name_Teacher;
                teachCalendarVM.ClassName = _unitOfWork.Class.GetById(teachCalendars[i].ClassID).Name;
                yield return teachCalendarVM;
            }
        }

        public bool UpdateTeachCalendar(TeachCalendarVM teachCalendarVM)
        {
            try
            {
                var teachCalendar = _mapper.Map<TeachCalendar>(teachCalendarVM);
                _unitOfWork.TeachCalendar.Update(teachCalendar);
                var check = _unitOfWork.Save();
                if(!check)
                {
                    return false;
                }    
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Cancel(int id)
        {
            try
            {
                var teachCalendar = _unitOfWork.TeachCalendar.Get(x => x.ID == id, false);
                if(teachCalendar == null)
                {
                    return false;
                }
                teachCalendar.StartTime = default;
                teachCalendar.EndTime = default;
                teachCalendar.Status = "TamHoan";
                _unitOfWork.TeachCalendar.Update(teachCalendar);
                var check = _unitOfWork.Save();
                if(!check)
                {
                    return false;
                }    
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
