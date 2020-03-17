using DataAccess.Dao;
using DataAccess.Dao.Interfaces;
using Domain.Reservation.Models;
using Domain.Room.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationDao _reservationDao;
        private readonly IRoomDao _roomDao;

        public ReservationService() : this(new ReservationDao(), new RoomDao())
        {

        }

        public ReservationService(IReservationDao reservationDao, IRoomDao roomDao)
        {
            _reservationDao = reservationDao;
            _roomDao = roomDao;
        }

        public List<ReservationModel> GetAllReservations()
        {
            List<DataAccess.Entities.Reservation> reservations = _reservationDao.GetAllReservations();

            List<int> roomIds = reservations.Select(x => x.RoomId).Distinct().ToList();

            List<DataAccess.Entities.Room> rooms = _roomDao.GetRoomByRoomsIds(roomIds);

            List<ReservationModel> allReservations = (from reservation in reservations
                                                      join room in rooms on reservation.RoomId equals room.Id
                                                      select new ReservationModel
                                                      {
                                                          ReservationId = reservation.Id,
                                                          RoomModel = new RoomModel
                                                          {
                                                              Id = room.Id,
                                                              Name = room.Name,
                                                              Number = room.Number,
                                                              MaxPerson = room.MaxPerson,
                                                              Price = room.Price
                                                          },
                                                          UserId = reservation.UserId,
                                                          StartDate = reservation.StartDate,
                                                          EndDate = reservation.EndDate
                                                      }).ToList();

            return allReservations;
        }

        public List<ReservationModel> GetUserReservations(int userId)
        {
            List<DataAccess.Entities.Reservation> userReservations = _reservationDao.GetReservationsByUserId(userId);

            List<int> roomIds = userReservations.Select(x => x.RoomId).ToList();

            List<DataAccess.Entities.Room> reservedRooms = _roomDao.GetRoomByRoomsIds(roomIds);

            List<ReservationModel> userReservationModels = (from reservation in userReservations
                                                            join room in reservedRooms on reservation.RoomId equals room.Id
                                                            select new ReservationModel
                                                            {
                                                                ReservationId = reservation.Id,
                                                                RoomModel = new RoomModel
                                                                {
                                                                    Id = room.Id,
                                                                    Name = room.Name,
                                                                    Number = room.Number,
                                                                    MaxPerson = room.MaxPerson,
                                                                    Price = room.Price
                                                                },
                                                                UserId = reservation.UserId,
                                                                StartDate = reservation.StartDate,
                                                                EndDate = reservation.EndDate
                                                            }).ToList();

            return userReservationModels;
        }

        public List<int> GetReservedRoomsIdsByDateRange(DateTime reservationStartDate, DateTime reservationEndDate)
        {
            List<DataAccess.Entities.Reservation> reservations = _reservationDao.GetReservationsByDateRange(reservationStartDate, reservationEndDate);

            List<int> reservedRoomIds = reservations.Select(x => x.RoomId).ToList();

            return reservedRoomIds;
        }

        public void DoReservation(ReservationModel reservationModel)
        {
            DataAccess.Entities.Reservation reservation = reservationModel.ToDto();

            _reservationDao.Insert(reservation);
        }
    }
}
