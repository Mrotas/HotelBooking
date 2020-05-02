using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
