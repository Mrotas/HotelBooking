using Common.Enum;
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
        public int Status { get; set; }
        public string StatusDescription
        {
            get
            {
                switch (Status)
                {
                    case (int) ReservationStatus.New:
                        return "Oczekuje na akceptacje";
                    case (int) ReservationStatus.Accepted:
                        return "Zaakceptowano";
                    case (int) ReservationStatus.Cancelled:
                        return "Odwołano";
                    default:
                        return "";
                }
            }
        }

        public DataAccess.Entities.Reservation ToDto()
        {
            return new DataAccess.Entities.Reservation
            {
                RoomId = RoomModel.Id,
                UserId = UserId,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = Status
            };
        }
    }
}
