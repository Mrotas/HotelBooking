using Domain.Room;
using Domain.Room.Models;
using Domain.Room.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HootelRoomMVC.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController() : this(new RoomService())
        {

        }

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SearchRoom(SearchRoomModel searchRoomModel)
        {
            IList<RoomViewModel> matchRooms = _roomService.GetRoomModels(searchRoomModel);
            return Json(matchRooms, JsonRequestBehavior.AllowGet);
        }
    }
}