using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.ReportService
{
    public interface IReportService
    {
        Task<IEnumerable<ReportVM>> GetReports(int? top = null);
        ReportVM GetReportById(int id);
        Task<IEnumerable<ReportVM>> GetReportsByMonth(int month);
        bool AddReport(ReportVM reportVM);
        bool DeleteReport(int id);
        bool UpdateReport(ReportVM reportVM);
    }
}
