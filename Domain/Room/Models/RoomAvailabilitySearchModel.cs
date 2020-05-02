using System;

namespace Domain.Room.Models
{
    public class RoomAvailabilitySearchModel
    {
        public int RoomId { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
    }
}
