using System.Collections.Generic;

namespace Domain.Reservation.ViewModels
{
    public class ConfirmationViewModel
    {
        public int RoomNumber { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string RoomName { get; set; }
        public List<string> RoomOptions { get; set; }
        public string TotalPriceString { get; set; }
        public string ReservationStartDate { get; set; }
        public string ReservationEndDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
