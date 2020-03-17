using DataAccess.Dao;
using DataAccess.Dao.Criteria;
using DataAccess.Dao.Interfaces;
using Domain.Reservation;
using Domain.Room.Models;
using Domain.Room.ViewModels;
using Domain.RoomOption;
using Domain.RoomOption.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomDao _roomDao;
        private readonly IRoomOptionService _roomOptionService;
        private readonly IReservationService _reservationService;

        public RoomService() : this(new RoomDao(), new RoomOptionService(), new ReservationService())
        {

        }

        public RoomService(IRoomDao roomDao, IRoomOptionService roomOptionService, IReservationService reservationService)
        {
            _roomDao = roomDao;
            _roomOptionService = roomOptionService;
            _reservationService = reservationService;
        }

        public IList<RoomViewModel> GetRoomModels(SearchRoomModel searchRoomModel)
        {
            var searchRoomCriteria = new SearchRoomCriteria
            {
                Adults = searchRoomModel.Adults ?? 0,
                Children = searchRoomModel.Children ?? 0,
                AirConditioning = searchRoomModel.AirConditioning,
                Balcony = searchRoomModel.Balcony,
                ChildBed = searchRoomModel.ChildBed,
                WiFi = searchRoomModel.WiFi
            };

            IList<DataAccess.Entities.Room> rooms = _roomDao.GetRooms(searchRoomCriteria);

            List<int> reservedRoomsIds = _reservationService.GetReservedRoomsIdsByDateRange(searchRoomModel.ReservationStartDate, searchRoomModel.ReservationEndDate);

            List<DataAccess.Entities.Room> availableRooms = rooms.Where(x => !reservedRoomsIds.Contains(x.Id)).ToList();

            List<RoomOptionModel> roomOptions = _roomOptionService.GetRoomOptions(searchRoomCriteria);

            List<DataAccess.Entities.Room> availableRoomsWithSelectedOptions = availableRooms.Where(x => roomOptions.Any(ro => ro.RoomId == x.Id)).ToList();

            List<RoomViewModel> matchRooms = (from room in availableRoomsWithSelectedOptions
                                              join roomOption in roomOptions on room.Id equals roomOption.RoomId
                                              select new RoomViewModel
                                              {
                                                  RoomModel = new RoomModel
                                                  {
                                                      Id = room.Id,
                                                      Name = room.Name,
                                                      Number = room.Number,
                                                      MaxPerson = room.MaxPerson,
                                                      Price = room.Price,
                                                      RoomOptionModel = roomOption
                                                  },
                                                  TotalPrice = GetTotalPrice(searchRoomModel.ReservationStartDate, searchRoomModel.ReservationEndDate, room.Price)
                                              }).ToList();

            return matchRooms;
        }

        public List<RoomModel> GetRoomModelsByRoomIds(List<int> roomIds)
        {
            List<DataAccess.Entities.Room> rooms = _roomDao.GetRoomByRoomsIds(roomIds);

            List<RoomOptionModel> roomOptionModels = _roomOptionService.GetRoomOptionsByRoomIds(roomIds);

            List<RoomModel> roomModels = (from room in rooms
                                          join roomOption in roomOptionModels on room.Id equals roomOption.RoomId
                                          select new RoomModel
                                          {
                                              Id = room.Id,
                                              Name = room.Name,
                                              Number = room.Number,
                                              MaxPerson = room.MaxPerson,
                                              Price = room.Price,
                                              RoomOptionModel = roomOption
                                          }).ToList();

            return roomModels;
        }

        public RoomModel GetRoomModel(int roomId)
        {
            DataAccess.Entities.Room room = _roomDao.GetRoomByRoomId(roomId);
            RoomOptionModel roomOptionModel = _roomOptionService.GetRoomOptionByRoomId(roomId);

            var roomModel = new RoomModel
            {
                Id = room.Id,
                MaxPerson = room.MaxPerson,
                Name = room.Name,
                Number = room.Number,
                Price = room.Price,
                RoomOptionModel = roomOptionModel
            };

            return roomModel;
        }

        public RoomModel GetRoomModelByRoomName(string roomName)
        {
            DataAccess.Entities.Room room = _roomDao.GetRoomByRoomName(roomName);
            RoomOptionModel roomOptionModel = _roomOptionService.GetRoomOptionByRoomId(room.Id);

            var roomModel = new RoomModel
            {
                Id = room.Id,
                MaxPerson = room.MaxPerson,
                Name = room.Name,
                Number = room.Number,
                Price = room.Price,
                RoomOptionModel = roomOptionModel
            };

            return roomModel;
        }

        private double GetTotalPrice(DateTime reservationStartDate, DateTime reservationEndDate, double dayPrice)
        {
            TimeSpan reservationTimeSpan = reservationEndDate - reservationStartDate;

            return reservationTimeSpan.Days * dayPrice;
        }
    }
}
