using Domain.RoomOption.Models;

namespace Domain.Room.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int MaxPerson { get; set; }
        public double Price { get; set; }
        public RoomOptionModel RoomOptionModel { get; set; }
    }
}
