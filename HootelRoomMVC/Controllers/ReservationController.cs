using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common.Enum;
using Domain.Reservation;
using Domain.Reservation.Models;
using Domain.Reservation.ViewModels;
using Domain.Room;
using Domain.Room.Models;
using Domain.RoomOption.Models;
using Domain.User;
using Domain.User.Models;
using Microsoft.AspNet.Identity;

namespace HootelRoomMVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;

        public ReservationController() : this(new RoomService(), new ReservationService(), new UserService())
        {
        }

        public ReservationController(IRoomService roomService, IReservationService reservationService, IUserService userService)
        {
            _roomService = roomService;
            _reservationService = reservationService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyReservations()
        {
            return View();
        }

        public JsonResult GetReservations()
        {
            List<ReservationModel> reservations = _reservationService.GetAllReservations();

            return Json(reservations);
        }

        public JsonResult GetMyReservations()
        {
            string username = HttpContext.User.Identity.GetUserName();
            UserModel user = _userService.GetUserByUsername(username);

            List<ReservationModel> userReservations = _reservationService.GetUserReservations(user.UserId);

            return Json(userReservations);
        }

        public ActionResult Confirmation(int roomId, string reservationStartDate, string reservationEndDate)
        {
            RoomModel roomModel = _roomService.GetRoomModel(roomId);
            string username = HttpContext.User.Identity.GetUserName();
            UserModel user = _userService.GetUserByUsername(username);

            ConfirmationViewModel model = new ConfirmationViewModel
            {
                UserName = user.Name,
                UserLastName = user.LastName,
                UserEmail = user.Email,
                RoomNumber = roomModel.Number,
                RoomName = roomModel.Name,
                ReservationStartDate = reservationStartDate,
                ReservationEndDate = reservationEndDate,
                ImageUrl = @"../Images/" + roomModel.Name + ".jpg"
            };

            model.RoomOptions = GetViewRoomOptions(roomModel.RoomOptionModel);
            model.TotalPriceString = GetTotalPriceString(reservationStartDate, reservationEndDate, roomModel.Price);

            return View(model);
        }

        public ActionResult DoReservation(string roomName, string reservationStartDate, string reservationEndDate)
        {
            RoomModel roomModel = _roomService.GetRoomModelByRoomName(roomName);
            string username = HttpContext.User.Identity.GetUserName();
            UserModel user = _userService.GetUserByUsername(username);

            var reservationModel = new ReservationModel
            {
                RoomModel = roomModel,
                UserId = user.UserId,
                StartDate = DateTime.ParseExact(reservationStartDate, "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact(reservationEndDate, "dd/MM/yyyy", null),
                Status = (int) ReservationStatus.New
            };

            _reservationService.DoReservation(reservationModel);

            return View("Summary", reservationModel);
        }

        public JsonResult AcceptReservation(int reservationId)
        {
            _reservationService.AcceptReservation(reservationId);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RequestReservationCancellation(int reservationId)
        {
            _reservationService.RequestReservationCancellation(reservationId);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CancelReservation(int reservationId)
        {
            _reservationService.CancelReservation(reservationId);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteReservation(int reservationId)
        {
            _reservationService.DeleteReservation(reservationId);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private List<string> GetViewRoomOptions(RoomOptionModel roomOptionModel)
        {
            var roomOptions = new List<string>();

            if (roomOptionModel.OnePersonBed >= 1)
            {
                roomOptions.Add($"1 osobowe łóżka: {roomOptionModel.OnePersonBed}");
            }
            if (roomOptionModel.TwoPersonBed >= 1)
            {
                roomOptions.Add($"2 osobowe łóżka: {roomOptionModel.TwoPersonBed}");
            }
            if (roomOptionModel.AirConditioning)
            {
                roomOptions.Add("Klimatyzacja");
            }
            if (roomOptionModel.Balcony)
            {
                roomOptions.Add("Balkon");
            }
            if (roomOptionModel.ChildBed)
            {
                roomOptions.Add("Łóżko dziecięce");
            }
            if (roomOptionModel.WiFi)
            {
                roomOptions.Add("WiFi");
            }

            return roomOptions;
        }

        private string GetTotalPriceString(string reservationStartDate, string reservationEndDate, double dayPrice)
        {
            DateTime startDate = DateTime.ParseExact(reservationStartDate, "dd/MM/yyyy", null);
            DateTime endDate = DateTime.ParseExact(reservationEndDate, "dd/MM/yyyy", null);

            TimeSpan reservationTimeSpan = endDate - startDate;

            double totalPrice = reservationTimeSpan.Days * dayPrice;

            return totalPrice + "zł";
        }
    }
}