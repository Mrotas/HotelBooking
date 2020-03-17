namespace DataAccess.Dao.Criteria
{
    public class SearchRoomCriteria
    {
        public int Adults { get; set; }
        public int Children { get; set; }
        public bool ChildBed { get; set; }
        public bool AirConditioning { get; set; }
        public bool WiFi { get; set; }
        public bool Balcony { get; set; }
    }
}
