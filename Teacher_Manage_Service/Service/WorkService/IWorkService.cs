using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.WorkService
{
    public interface IWorkService
    {
        WorkVM GetWorkByID(int id);
        Task<IEnumerable<WorkVM>> GetWorks(bool allowTracking = true);
        bool Delete(int id);
        bool AddWork(WorkVM workVM);
        bool Update(WorkVM workVM);
    }
}
