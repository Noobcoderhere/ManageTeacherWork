using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.WorkService
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddWork(WorkVM workVM)
        {
            try
            {
                workVM.CreatedDate = DateTime.Now;
                workVM.ModifiedDate = DateTime.Now;
                var work = _mapper.Map<Work>(workVM);
                _unitOfWork.Work.Add(work);
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

        public bool Delete(int id)
        {
            try
            {
                var work = _unitOfWork.Work.GetById(id);
                if(work == null)
                {
                    return false;
                }
                _unitOfWork.Work.Delete(work);
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

        public WorkVM GetWorkByID(int id)
        {
            var work = _unitOfWork.Work.GetById(id);
            return _mapper.Map<WorkVM>(work);
        }

        public async Task<IEnumerable<WorkVM>> GetWorks(bool allowTracking = true)
        {
            var works = await _unitOfWork.Work.GetAllAsync(allowTracking);
            return works.Select(x => _mapper.Map<WorkVM>(x));
        }

        public bool Update(WorkVM workVM)
        {
            try
            {
                workVM.ModifiedDate = DateTime.Now;
                var work = _mapper.Map<Work>(workVM);
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
    }
}
