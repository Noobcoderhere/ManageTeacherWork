using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.FileService
{
    public interface IFileService
    {
        Task<IEnumerable<FileVM>> GetFiles();
        FileVM GetFileById(int id);
        bool AddFile(FileVM fileVM);
        bool DeleteFile(int id);
        bool UpdateFile(FileVM fileVM);
    }
}
