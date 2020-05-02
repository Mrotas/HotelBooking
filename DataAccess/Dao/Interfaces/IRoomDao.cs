using DataAccess.Dao.Criteria;
using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Dao.Interfaces
{
    public interface IRoomDao
    {
        Room GetRoomByRoomId(int roomId);
        Room GetRoomByRoomName(string roomName);
        List<Room> GetRoomByRoomsIds(List<int> roomIds);
        IList<Room> GetRooms(SearchRoomCriteria criteria);
        IList<Room> GetAllRooms();
    }
}
