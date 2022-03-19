using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddReport(ReportVM reportVM)
        {
            try
            {
                var report = _mapper.Map<MonthReport>(reportVM);
                report.CreatedDate = DateTime.Now;
                _unitOfWork.MonthReport.Add(report);
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

        public bool DeleteReport(int id)
        {
            try
            {
                var report = _unitOfWork.MonthReport.GetById(id);
                if(report == null)
                {
                    return false;
                }
                _unitOfWork.MonthReport.Delete(report);
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

        public ReportVM GetReportById(int id)
        {
            var report = _unitOfWork.MonthReport.GetById(id);
            return _mapper.Map<ReportVM>(report);
        }

        public async Task<IEnumerable<ReportVM>> GetReports(int? top)
        {
            if(top != null)
            {
                var reports = await _unitOfWork.MonthReport.GetAllAsync();
                return reports.Select(x => _mapper.Map<ReportVM>(x)).OrderByDescending(y => y.CreatedDate).Take((int)top);
            }  
            else
            {
                var reports = await _unitOfWork.MonthReport.GetAllAsync();
                return reports.Select(x => _mapper.Map<ReportVM>(x));
            }    
        }

        public async Task<IEnumerable<ReportVM>> GetReportsByMonth(int month)
        {
            var reports = await _unitOfWork.MonthReport.GetManyAsync(x => x.Date.Month == month);
            return reports.Select(x => _mapper.Map<ReportVM>(x));
        }

        public bool UpdateReport(ReportVM reportVM)
        {
            try
            {
                var report = _mapper.Map<MonthReport>(reportVM);
                _unitOfWork.MonthReport.Update(report);
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
