using Domain.Room.Models;
using System;

namespace Domain.Reservation.Models
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public RoomModel RoomModel { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DataAccess.Entities.Reservation ToDto()
        {
            return new DataAccess.Entities.Reservation
            {
                RoomId = RoomModel.Id,
                UserId = UserId,
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
