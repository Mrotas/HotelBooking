using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class RoomOption
    {
        [Key]
        public int RoomId { get; set; }
        public int OnePersonBed { get; set; }
        public int TwoPersonBed { get; set; }
        public bool ChildBed { get; set; }
        public bool AirConditioning { get; set; }
        public bool WiFi { get; set; }
        public bool Balcony { get; set; }
    }
}
