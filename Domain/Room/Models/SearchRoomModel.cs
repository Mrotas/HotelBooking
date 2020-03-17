using System;

namespace Domain.Room.Models
{
    public class SearchRoomModel
    {
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public bool ChildBed { get; set; }
        public bool AirConditioning { get; set; }
        public bool WiFi { get; set; }
        public bool Balcony { get; set; }
    }
}
