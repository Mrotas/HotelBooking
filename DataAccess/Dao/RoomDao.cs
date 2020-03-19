using DataAccess.Dao.Criteria;
using DataAccess.Dao.Interfaces;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao
{
    public class RoomDao : IRoomDao
    {
        public Room GetRoomByRoomId(int roomId)
        {
            using (var db = new HotelBookingDb())
            {
                Room room = db.Room.Single(x => x.Id == roomId);
                return room;
            }
        }
        public Room GetRoomByRoomName(string roomName)
        {
            using (var db = new HotelBookingDb())
            {
                Room room = db.Room.Single(x => x.Name == roomName);
                return room;
            }
        }

        public List<Room> GetRoomByRoomsIds(List<int> roomIds)
        {
            using (var db = new HotelBookingDb())
            {
                List<Room> rooms = db.Room.Where(x => roomIds.Contains(x.Id)).ToList();
                return rooms;
            }
        }

        public IList<Room> GetRooms(SearchRoomCriteria criteria)
        {
            int personNumber = criteria.Adults + criteria.Children;
            using (var db = new HotelBookingDb())
            {
                List<Room> rooms = db.Room.Where(x => x.MaxPerson >= personNumber).ToList();
                return rooms;
            }
        }
    }
}
