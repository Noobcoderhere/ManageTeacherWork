using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.FileService
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddFile(FileVM fileVM)
        {
            try
            {
                var file = _mapper.Map<File>(fileVM);
                _unitOfWork.File.Add(file);
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

        public bool DeleteFile(int id)
        {
            try
            {
                var file = _unitOfWork.File.GetById(id);
                if(file == null)
                {
                    return false;
                }
                _unitOfWork.File.Delete(file);
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


        public FileVM GetFileById(int id)
        {
            var file = _unitOfWork.File.GetById(id);
            return _mapper.Map<FileVM>(file);
        }

        public async Task<IEnumerable<FileVM>> GetFiles()
        {
            var files = await _unitOfWork.File.GetAllAsync();
            return files.Select(x => _mapper.Map<FileVM>(x));
        }

        public bool UpdateFile(FileVM fileVM)
        {
            try
            {
                var file = _mapper.Map<File>(fileVM);
                _unitOfWork.File.Update(file);
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
    }
}
