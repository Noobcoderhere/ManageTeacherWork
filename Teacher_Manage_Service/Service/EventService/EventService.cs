using AutoMapper;
using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.EventService
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddEvent(Event addEvent)
        {
            try
            {
                _unitOfWork.Event.Add(addEvent);
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

        public bool DeleteEvent(int id)
        {
            try
            {
                var _event = _unitOfWork.Event.GetById(id);
                if (_event == null)
                {
                    return false;
                }
                _unitOfWork.Event.Delete(_event);
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

        public async Task<EventVM> GetEventById(int id)
        {
            var _event = await _unitOfWork.Event.GetAsync(x => x.ID == id, false);
            return _mapper.Map<EventVM>(_event);
        }

        public async Task<IEnumerable<EventVM>> GetEvents(int? userID)
        {
            if(userID == null)
            {
                var events = await _unitOfWork.Event.GetAllAsync();
                return events.Select(x => _mapper.Map<EventVM>(x));
            }    
            else
            {
                var events = await _unitOfWork.Event.GetManyAsync(x => x.UserID == userID);
                return events.Select(x => _mapper.Map<EventVM>(x));
            }    
        }

        public bool UpdateEvent(Event updateEvent)
        {
            try
            {
                _unitOfWork.Event.Update(updateEvent);
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
