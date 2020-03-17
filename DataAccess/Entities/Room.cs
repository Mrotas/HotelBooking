using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int MaxPerson { get; set; }
        public double Price { get; set; }
    }
}
