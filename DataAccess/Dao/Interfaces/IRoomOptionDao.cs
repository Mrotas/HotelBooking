using DataAccess.Dao.Criteria;
using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Dao.Interfaces
{
    public interface IRoomOptionDao
    {
        RoomOption GetRoomOptionByRoomId(int roomId);
        IList<RoomOption> GetRoomOptionsByRoomIds(List<int> roomIds);
        IList<RoomOption> GetRoomOptions(RoomOptionDaoCriteria criteria);
        IList<RoomOption> GetAllRoomOptions();
    }
}
