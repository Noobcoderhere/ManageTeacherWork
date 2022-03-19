using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Contract;
using System.Linq.Expressions;
using System.Linq;

namespace Teacher_Manage_Service.Service.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddClass(ClassVM classVM)
        {
            try
            {
                classVM.CreatedDate = classVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                classVM.ModifiedDate = DateTime.Now;
                var classs = _mapper.Map<Class>(classVM);
                _unitOfWork.Class.Add(classs);
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

        public bool DeleteClass(int id)
        {
            try
            {
                var classs = _unitOfWork.Class.GetById(id);
                if (classs == null)
                {
                    return false;
                }
                _unitOfWork.Class.Delete(classs);
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

        public ClassVM GetClassById(int id)
        {
            var classs = _unitOfWork.Class.GetById(id);
            var classVM = _mapper.Map<ClassVM>(classs);
            classVM.MajorName = GetMajorName(classs.MajorID);
            classVM.TeacherName = GetTeacherName(classs.TeacherID);
            return classVM;
        }

        public async Task<IEnumerable<ClassVM>> GetClasses(bool allowTracking = true)
        {
            var classes = await _unitOfWork.Class.GetAllAsync(allowTracking);
            var teachCalendars = (await _unitOfWork.TeachCalendar.GetAllAsync(allowTracking)).ToList();
            List<ClassVM> classVMs = new List<ClassVM>();
            foreach (var item in classes)
            {
                var classVM = _mapper.Map<ClassVM>(item);
                var teachCalendar = teachCalendars.FirstOrDefault(x => x.ClassID == item.ID && DateTime.Now.CompareTo(x.StartTime) >= 0 && DateTime.Now.CompareTo(x.EndTime) <= 0);
                if(teachCalendar != null)
                {
                    var str = "Đang có tiết " + teachCalendar.Subject_Name + " tại phòng " + teachCalendar.Room + " dạy bởi giảng viên " + teachCalendar.Teacher.Name_Teacher + " tới " + Convert.ToDateTime(teachCalendar.EndTime).ToString("hh:mm tt");
                    classVM.HavingClass = str;
                }
                else
                    classVM.HavingClass = string.Empty;
                classVM.MajorName = GetMajorName(item.MajorID);
                classVM.TeacherName = GetTeacherName(item.TeacherID);
                classVMs.Add(classVM);
            }
            return classVMs;
        }

        public async Task<IEnumerable<ClassVM>> GetClassesByCondition(Expression<Func<Class, bool>> predicate, bool allowTracking = true)
        {
            var classes = await _unitOfWork.Class.GetManyAsync(predicate, allowTracking);
            var teachCalendars = (await _unitOfWork.TeachCalendar.GetAllAsync(allowTracking)).ToList();
            List<ClassVM> classVMs = new List<ClassVM>();
            foreach (var item in classes)
            {
                var classVM = _mapper.Map<ClassVM>(item);
                var teachCalendar = teachCalendars.FirstOrDefault(x => x.ClassID == item.ID && DateTime.Now.CompareTo(x.StartTime) >= 0 && DateTime.Now.CompareTo(x.EndTime) <= 0);
                if (teachCalendar != null)
                {
                    var str = "Đang có tiết " + teachCalendar.Subject_Name + " tại phòng " + teachCalendar.Room + " dạy bởi giảng viên " + teachCalendar.Teacher.Name_Teacher + " tới " + Convert.ToDateTime(teachCalendar.EndTime).ToString("hh:mm tt");
                    classVM.HavingClass = str;
                }
                else
                    classVM.HavingClass = string.Empty;
                classVM.MajorName = GetMajorName(item.MajorID);
                classVM.TeacherName = GetTeacherName(item.TeacherID);
                classVMs.Add(classVM);
            }
            return classVMs;
        }

        public bool UpdateClass(ClassVM classVM)
        {
            try
            {
                classVM.Name = classVM.Name.ToString();
                classVM.Address = classVM.Address.ToString();
                classVM.ModifiedDate = classVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                var classs = _mapper.Map<Class>(classVM);
                _unitOfWork.Class.Update(classs);
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

        private string GetMajorName(int majorId)
        {
            return _unitOfWork.Major.GetById(majorId).Name;
        }

        private string GetTeacherName(int teacherId)
        {
            return _unitOfWork.Teacher.GetById(teacherId).Name_Teacher;
        }
    }
}
