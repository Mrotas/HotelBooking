using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Dao.Interfaces
{
    public interface IReservationDao
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int reservationId);
        List<Reservation> GetReservationsByUserId(int userId);
        List<Reservation> GetReservationsByDateRange(DateTime reservationStartDate, DateTime reservationEndDate);
        void Insert(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void UpdateReservationStatus(int reservationId, int status);
        void Delete(int reservationId);
    }
}
