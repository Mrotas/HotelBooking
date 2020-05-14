using Domain.Reservation.Models;
using System;
using System.Collections.Generic;

namespace Domain.Reservation
{
    public interface IReservationService
    {
        List<ReservationModel> GetAllReservations();
        List<ReservationModel> GetUserReservations(int userId);
        List<int> GetReservedRoomsIdsByDateRange(DateTime reservationStartDate, DateTime reservationEndDate);
        void DoReservation(ReservationModel reservationModel);
        void AcceptReservation(int reservationId);
        void RequestReservationCancellation(int reservationId);
        void CancelReservation(int reservationId);
        void DeleteReservation(int reservationId);
        void RescheduleReservation(int reservationId, DateTime reservationStartDate, DateTime reservationEndDate);
    }
}
