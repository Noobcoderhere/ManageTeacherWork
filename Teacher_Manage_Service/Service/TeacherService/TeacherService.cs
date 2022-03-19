using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.Person;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddTeacher(TeacherVM teacherVM)
        {
            try
            {
                teacherVM.Name_Teacher = teacherVM.Name_Teacher.ToString().Trim();
                teacherVM.Phone = teacherVM.Phone.Trim();
                teacherVM.Address = teacherVM.Address != null ? teacherVM.Address.ToString().Trim() : string.Empty;
                teacherVM.Avatar = teacherVM.Avatar.ToString().Trim();
                teacherVM.Gender = teacherVM.Gender.ToString().Trim();
                teacherVM.CreatedDate = teacherVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                teacherVM.Status = teacherVM.Status.ToString();
                var teacher = _mapper.Map<Teacher>(teacherVM);
                _unitOfWork.Teacher.Add(teacher);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteTeacher(int id)
        {
            try
            {
                var teacher = _unitOfWork.Teacher.GetById(id);
                if (teacher == null)
                {
                    return false;
                }
                _unitOfWork.Teacher.Delete(teacher);
                var check = _unitOfWork.Save();
                if (!check)
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

        public TeacherVM GetTeacherById(int id)
        {
            var teacher = _unitOfWork.Teacher.GetById(id);
            return _mapper.Map<TeacherVM>(teacher);
        }

        public async Task<IEnumerable<TeacherVM>> GetTeachers(bool allowTracking = true)
        {
            var teachers = await _unitOfWork.Teacher.GetAllAsync(allowTracking);
            var teacherVMs = new List<TeacherVM>();
            foreach (var item in teachers)
            {
                var teachCalendars = _unitOfWork.TeachCalendar.GetMany(x => x.TeacherID == item.ID);
                var teacherVM = _mapper.Map<TeacherVM>(item);
                var rightNow = teachCalendars.Where(x => DateTime.Now.CompareTo(x.StartTime) >= 0 && DateTime.Now.CompareTo(x.EndTime) <= 0).FirstOrDefault();
                if (rightNow != null)
                {
                    string str;
                    str = "Lớp " + rightNow.Class.Name + ", phòng " + rightNow.Room + ", môn " + rightNow.Subject_Name + ", tới " + Convert.ToDateTime(rightNow.EndTime).ToString("hh:mm tt");
                    teacherVM.TeachingAt = str;
                }    
                else
                {
                    teacherVM.TeachingAt = String.Empty;
                }    
                teacherVMs.Add(teacherVM);
            }
            return teacherVMs;
        }

        public async Task<IEnumerable<TeacherVM>> GetTeachersByCondition(Expression<Func<Teacher, bool>> predicate, bool allowTracking = true)
        {
            var teachers = await _unitOfWork.Teacher.GetManyAsync(predicate, allowTracking);
            var teacherVMs = new List<TeacherVM>();
            foreach (var item in teachers)
            {
                var teachCalendars = _unitOfWork.TeachCalendar.GetMany(x => x.TeacherID == item.ID);
                var teacherVM = _mapper.Map<TeacherVM>(item);
                var rightNow = teachCalendars.Where(x => DateTime.Now.CompareTo(x.StartTime) >= 0 && DateTime.Now.CompareTo(x.EndTime) <= 0).FirstOrDefault();
                if (rightNow != null)
                {
                    string str;
                    str = "Lớp " + rightNow.Class.Name + ", phòng " + rightNow.Room + ", môn " + rightNow.Subject_Name + ", tới " + Convert.ToDateTime(rightNow.EndTime).ToString("hh:mm tt");
                    teacherVM.TeachingAt = str;
                }
                else
                {
                    teacherVM.TeachingAt = String.Empty;
                }
                teacherVMs.Add(teacherVM);
            }
            return teacherVMs;
        }

        public bool UpdateTeacher(TeacherVM teacherVM)
        {
            try
            {
                teacherVM.Name_Teacher = teacherVM.Name_Teacher.ToString().Trim();
                teacherVM.Phone = teacherVM.Phone.Trim();
                teacherVM.Address = teacherVM.Address != null ? teacherVM.Address.ToString().Trim() : string.Empty;
                teacherVM.DateOfBirth = teacherVM.DateOfBirth;
                teacherVM.Avatar = teacherVM.Avatar.ToString().Trim();
                teacherVM.Gender = teacherVM.Gender.ToString().Trim();
                teacherVM.ModifiedDate = teacherVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                teacherVM.Status = teacherVM.Status.ToString().Trim();
                teacherVM.MajorID = teacherVM.MajorID;
                var teacher = _mapper.Map<Teacher>(teacherVM);
                _unitOfWork.Teacher.Update(teacher);
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
