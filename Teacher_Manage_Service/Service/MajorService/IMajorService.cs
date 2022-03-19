using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.MajorService
{
    public interface IMajorService
    {
        Task<IEnumerable<MajorVM>> GetMajors(bool allowTracking = true);
        MajorVM GetMajorById(int id);
        bool UpdateMajor(MajorVM majorVM);
        bool AddMajor(MajorVM majorVM);
        bool DeleteMajor(int id);
    }
}
