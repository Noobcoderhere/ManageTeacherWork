using System.Collections.Generic;
using System.Threading.Tasks;
using Teacher_Manage_Core;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.EventService
{
    public interface IEventService
    {
        Task<IEnumerable<EventVM>> GetEvents(int? userID = null);
        Task<EventVM> GetEventById(int id);
        bool AddEvent(Event addEvent);
        bool DeleteEvent(int id);
        bool UpdateEvent(Event updateEvent);
    }
}
