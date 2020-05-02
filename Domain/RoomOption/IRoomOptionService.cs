using DataAccess.Dao.Criteria;
using Domain.RoomOption.Models;
using System.Collections.Generic;

namespace Domain.RoomOption
{
    public interface IRoomOptionService
    {
        RoomOptionModel GetRoomOptionByRoomId(int roomId);
        List<RoomOptionModel> GetRoomOptionsByRoomIds(List<int> roomIds);
        List<RoomOptionModel> GetAllRoomOptions();
        List<RoomOptionModel> GetRoomOptions(SearchRoomCriteria criteria);
    }
}
