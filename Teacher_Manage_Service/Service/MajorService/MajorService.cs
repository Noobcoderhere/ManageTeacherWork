using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.MajorService
{
    public class MajorService : IMajorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MajorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public bool AddMajor(MajorVM majorVM)
        {
            try
            {
                majorVM.Name = majorVM.Name.ToString().Trim() ?? "";
                majorVM.Address = majorVM.Address.ToString().Trim() ?? "";
                majorVM.Description = majorVM.Description ?? "";
                majorVM.Founding = majorVM.Founding;
                majorVM.CreatedDate = majorVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                majorVM.ModifiedDate = DateTime.Now;
                var major = _mapper.Map<Major>(majorVM);
                _unitOfWork.Major.Add(major);
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

        public bool DeleteMajor(int id)
        {
            try
            {
                var major = _unitOfWork.Major.GetById(id);
                if(major == null)
                {
                    return false;
                }
                _unitOfWork.Major.Delete(major);
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

        public MajorVM GetMajorById(int id)
        {
            var major = _unitOfWork.Major.GetById(id);
            return _mapper.Map<MajorVM>(major);
        }

        public async Task<IEnumerable<MajorVM>> GetMajors(bool allowTracking = true)
        {
            var majors = await _unitOfWork.Major.GetAllAsync(allowTracking);
            return majors.Select(x => _mapper.Map<MajorVM>(x));
        }

        public bool UpdateMajor(MajorVM majorVM)
        {
            try
            {
                majorVM.Name = majorVM.Name.ToString().Trim() ?? "";
                majorVM.Address = majorVM.Address.ToString().Trim() ?? "";
                majorVM.Description = majorVM.Description ?? "";
                majorVM.Founding = majorVM.Founding;
                majorVM.ModifiedDate = majorVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                _unitOfWork.Major.Update(_mapper.Map<Major>(majorVM));
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
