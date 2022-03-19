using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.Person;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddStudent(StudentVM studentVM)
        {
            try
            {
                studentVM.Name_Student = studentVM.Name_Student.ToString().Trim() ?? "";
                studentVM.Address = studentVM.Address.ToString().Trim() ?? "";
                studentVM.Email = studentVM.Email ?? "";
                studentVM.Phone = studentVM.Phone.ToString().Trim() ?? "";
                studentVM.CreatedDate = studentVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                studentVM.ModifiedDate = DateTime.Now;
                var student = _mapper.Map<Student>(studentVM);
                _unitOfWork.Student.Add(student);
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

        public bool DeleteStudent(int id)
        {
            try
            {
                var student = _unitOfWork.Student.GetById(id);
                if(student == null)
                {
                    return false;
                }
                _unitOfWork.Student.Delete(student);
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

        public StudentVM GetStudentById(int id)
        {
            var student = _unitOfWork.Student.GetById(id);
            return _mapper.Map<StudentVM>(student);
        }

        public async Task<IEnumerable<StudentVM>> GetStudents(bool allowTracking = true)
        {
            var students = await _unitOfWork.Student.GetAllAsync(allowTracking);
            return students.Select(x => _mapper.Map<StudentVM>(x));
        }

        public async Task<IEnumerable<StudentVM>> GetStudentsByCondition(Expression<Func<Student, bool>> predicate, bool allowTracking = true)
        {
            var students = await _unitOfWork.Student.GetManyAsync(predicate, allowTracking);
            return students.Select(x => _mapper.Map<StudentVM>(x));
        }

        public bool UpdateStudent(StudentVM studentVM)
        {
            try
            {
                studentVM.Name_Student = studentVM.Name_Student.ToString().Trim();
                studentVM.Address = studentVM.Address.ToString().Trim();
                studentVM.Phone = studentVM.Phone.ToString().Trim();
                studentVM.ModifiedDate = studentVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                var student = _mapper.Map<Student>(studentVM);
                _unitOfWork.Student.Update(student);
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
