using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.WorkingCalendar;
using Teacher_Manage_Repository.Contract;
using System.Linq.Expressions;

namespace Teacher_Manage_Service.Service.WorkingCalendarService
{
    public class WorkingCalendarService : IWorkingCalendarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkingCalendarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddWorkingCalendar(WorkingCalendarVM workingCalendarVM)
        {
            try
            {
                var workingCalendar = _mapper.Map<CalendarWorking>(workingCalendarVM);
                workingCalendar.WorkState = "DangThucHien";
                workingCalendar.ModifiedDate = DateTime.Now;
                workingCalendar.CreatedDate = DateTime.Now;

                var work = _unitOfWork.Work.GetById(workingCalendarVM.WorkID);
                work.Status = "DangLam";
                work.ModifiedDate = DateTime.Now;
                _unitOfWork.Work.Update(work);

                _unitOfWork.WorkingCalendar.Add(workingCalendar);
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

        public bool DeleteWorkingCalendar(int id)
        {
            try
            {
                var workingCalendar = _unitOfWork.WorkingCalendar.GetById(id);
                if (workingCalendar == null)
                {
                    return false;
                }
                _unitOfWork.WorkingCalendar.Delete(workingCalendar);
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

        public WorkingCalendarVM GetWorkingCalendarById(int id)
        {
            var workingCalendar = _unitOfWork.WorkingCalendar.GetById(id);
            var workingCalendarVM = _mapper.Map<WorkingCalendarVM>(workingCalendar);
            workingCalendarVM.Teacher_Name = GetTeacherName(workingCalendar.TeacherID);
            workingCalendarVM.TypeCalendar_Name = GetCalendarTypeName(workingCalendar.TypeCalendarID);
            workingCalendarVM.Work_Name = GetWorkName(workingCalendar.WorkID);
            return workingCalendarVM;
        }

        public async Task<IEnumerable<WorkingCalendarVM>> GetWorkingCalendars(bool allowTracking = true)
        {
            var workingCalendars = await _unitOfWork.WorkingCalendar.GetAllAsync(allowTracking);
            var workingCalendarVMs = new List<WorkingCalendarVM>();
            foreach (var item in workingCalendars)
            {
                var workingCalendarVM = _mapper.Map<WorkingCalendarVM>(item);
                workingCalendarVM.TypeCalendar_Name = GetCalendarTypeName(item.TypeCalendarID);
                workingCalendarVM.Work_Name = GetWorkName(item.WorkID);
                workingCalendarVM.Teacher_Name = GetTeacherName(item.TeacherID);
                workingCalendarVMs.Add(workingCalendarVM);
            }
            return workingCalendarVMs;
        }

        public bool UpdateWorkingCalendar(WorkingCalendarVM workingCalendarVM)
        {
            try
            {
                var workingCalendar = _mapper.Map<CalendarWorking>(workingCalendarVM);
                workingCalendar.ModifiedDate = DateTime.Now;
                _unitOfWork.WorkingCalendar.Update(workingCalendar);
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

        public bool Completed(int id)
        {
            try
            {
                var workingCalendar = _unitOfWork.WorkingCalendar.Get(x => x.ID == id, false);
                if (workingCalendar == null)
                {
                    return false;
                }
                workingCalendar.WorkState = "DaHoanThanh";
                workingCalendar.ModifiedDate = DateTime.Now;

                var work = _unitOfWork.Work.Get(x => x.ID == workingCalendar.WorkID, false);
                if(work == null)
                {
                    return false;
                }    
                work.Status = "HoanThanh";
                work.ModifiedDate = DateTime.Now;

                _unitOfWork.Work.Update(work);
                _unitOfWork.WorkingCalendar.Update(workingCalendar);
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

        private string GetTeacherName(int teacherId)
        {
            var name = _unitOfWork.Teacher.GetById(teacherId).Name_Teacher ?? string.Empty;
            return name;
        }

        private string GetWorkName(int workId)
        {
            var name = _unitOfWork.Work.GetById(workId).Name_Work ?? string.Empty;
            return name;
        }

        private string GetCalendarTypeName(int typeCalId)
        {
            var name = _unitOfWork.WorkingCalendarType.GetById(typeCalId).TypeName ?? string.Empty;
            return name;
        }

        public async Task<IEnumerable<CalendarTypeVM>> GetCalendarTypes(bool allowTracking = true)
        {
            var calendarTypes = await _unitOfWork.WorkingCalendarType.GetAllAsync(allowTracking);
            return calendarTypes.Select(x => _mapper.Map<CalendarTypeVM>(x));
        }

        public CalendarTypeVM GetCalendarTypeById(int id)
        {
            var calendarType = _unitOfWork.WorkingCalendarType.GetById(id);
            return _mapper.Map<CalendarTypeVM>(calendarType);
        }

        public bool AddCalendarType(CalendarTypeVM calendarTypeVM)
        {
            try
            {
                calendarTypeVM.CreatedDate = DateTime.Now;
                calendarTypeVM.ModifiedDate = DateTime.Now;
                var calendarType = _mapper.Map<TypeCalendar>(calendarTypeVM);
                _unitOfWork.WorkingCalendarType.Add(calendarType);
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

        public bool DeleteCalendarType(int id)
        {
            try
            {
                var calendarType = _unitOfWork.WorkingCalendarType.GetById(id);
                if (calendarType == null)
                {
                    return false;
                }
                _unitOfWork.WorkingCalendarType.Delete(calendarType);
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

        public bool UpdateCalendarType(CalendarTypeVM calendarTypeVM)
        {
            try
            {
                calendarTypeVM.ModifiedDate = DateTime.Now;
                var calendarType = _mapper.Map<TypeCalendar>(calendarTypeVM);
                _unitOfWork.WorkingCalendarType.Update(calendarType);
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

        public bool Cancel(int id)
        {
            try
            {
                var workingCalendar = _unitOfWork.WorkingCalendar.Get(x => x.ID == id);
                var work = _unitOfWork.Work.Get(x => x.ID == workingCalendar.WorkID);
                if(workingCalendar == null || work == null)
                {
                    return false;
                }
                workingCalendar.ModifiedDate = DateTime.Now;
                workingCalendar.WorkState = "TamHoan";
                _unitOfWork.WorkingCalendar.Update(workingCalendar);

                work.Status = "ChuaLam";
                work.ModifiedDate = DateTime.Now;
                _unitOfWork.Work.Update(work);

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

        public bool Continue(int id)
        {
            try
            {
                var workingCalendar = _unitOfWork.WorkingCalendar.Get(x => x.ID == id);
                var work = _unitOfWork.Work.Get(x => x.ID == workingCalendar.WorkID);
                if (workingCalendar == null || work == null)
                {
                    return false;
                }
                workingCalendar.ModifiedDate = DateTime.Now;
                workingCalendar.WorkState = "DangThucHien";
                _unitOfWork.WorkingCalendar.Update(workingCalendar);

                work.Status = "DangLam";
                work.ModifiedDate = DateTime.Now;
                _unitOfWork.Work.Update(work);

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

        public WorkingCalendarVM GetWorkingCalendarByCondition(Expression<Func<CalendarWorking, bool>> predicate, bool allowTracking = true)
        {
            var workingCalendar = _unitOfWork.WorkingCalendar.Get(predicate, allowTracking);
            return _mapper.Map<WorkingCalendarVM>(workingCalendar);
        }
    }
}
