using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Managing_Teacher_Web.Common;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Core;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Service.Service.EventService;
using Teacher_Manage_Service.Service.UserService;

namespace Managing_Teacher_Work.Controllers
{
    public class EventController : BaseController
    { 
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService,IUserService userService, IMapper mapper)
        {
            _eventService = eventService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _eventService.GetEvents();
            ViewBag.listEvent = model.OrderByDescending(y => y.Start).ToList();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var check = _eventService.DeleteEvent(id);
            if(check)
            {
                SetAlert("Xoá thành công! :D", "success");
                return RedirectToAction("Index");
            }    
            else
            {
                SetAlert("Xoá thất bại! D:", "error");
                return RedirectToAction("Index");
            }       
        }



        [HttpPost]
        public async Task<JsonResult> SaveEvent(EventVM e)
        {
            var status = false;
            try
            {
                var _event = await _eventService.GetEventById(e.ID);
                if (_event != null)
                {
                    var updateEvent = _mapper.Map<Event>(e);
                    updateEvent.UserID = GetUserID();
                    var check = _eventService.UpdateEvent(updateEvent);
                    if (!check)
                    {
                        status = false;
                    }
                    else
                    {
                        status = true;
                    }
                }
                else
                {
                    var addEvent = _mapper.Map<Event>(e);
                    addEvent.UserID = GetUserID();
                    var check = _eventService.AddEvent(addEvent);
                    if (!check)
                    {
                        status = false;
                    }
                    else
                    {
                        status = true;
                    }
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult CalendarNote()
        {
            return View();
        }

        public async Task<JsonResult> GetEvents()
        {

            var events = await _eventService.GetEvents(GetUserID());
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = _eventService.DeleteEvent(eventID);
            return new JsonResult { Data = new { status = status } };
        }

        private int GetUserID()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            return session.ID;
        }
    }
}