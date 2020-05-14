using DataAccess.Dao.Interfaces;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao
{
    public class ReservationDao : IReservationDao
    {
        public List<Reservation> GetAllReservations()
        {
            using (var db = new HotelBookingDb())
            {
                List<Reservation> reservations = db.Reservation.ToList();
                return reservations;
            }
        }

        public Reservation GetReservationById(int reservationId)
        {
            using (var db = new HotelBookingDb())
            {
                Reservation reservation = db.Reservation.Single(x => x.Id == reservationId);
                return reservation;
            }
        }

        public List<Reservation> GetReservationsByUserId(int userId)
        {
            using (var db = new HotelBookingDb())
            {
                List<Reservation> reservations = db.Reservation.Where(x => x.UserId == userId).ToList();
                return reservations;
            }
        }

        public List<Reservation> GetReservationsByDateRange(DateTime reservationStartDate, DateTime reservationEndDate)
        {
            using (var db = new HotelBookingDb())
            {
                List<Reservation> reservations = db.Reservation.Where(x => x.StartDate >= reservationStartDate && x.StartDate <= reservationEndDate ||
                                                                        reservationStartDate >= x.StartDate && reservationStartDate <= x.EndDate).ToList();
                return reservations;
            }
        }

        public void Insert(Reservation reservation)
        {
            using (var db = new HotelBookingDb())
            {
                db.Reservation.Add(reservation);
                db.SaveChanges();
            }
        }
        
        public void UpdateReservation(Reservation reservationEntity)
        {
            using (var db = new HotelBookingDb())
            {
                Reservation reservation = db.Reservation.Single(x => x.Id == reservationEntity.Id);

                reservation.RoomId = reservationEntity.Status;
                reservation.UserId = reservationEntity.UserId;
                reservation.StartDate = reservationEntity.StartDate;
                reservation.EndDate = reservationEntity.EndDate;
                reservation.Status = reservationEntity.Status;

                db.SaveChanges();
            }
        }

        public void UpdateReservationStatus(int reservationId, int status)
        {
            using (var db = new HotelBookingDb())
            {
                Reservation reservation = db.Reservation.Single(x => x.Id == reservationId);
                reservation.Status = status;

                db.SaveChanges();
            }
        }

        public void Delete(int reservationId)
        {
            using (var db = new HotelBookingDb())
            {
                Reservation reservation = db.Reservation.Single(x => x.Id == reservationId);

                db.Reservation.Remove(reservation);
                db.SaveChanges();
            }
        }
    }
}
