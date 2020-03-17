using Domain.Room.Models;
using Domain.Room.ViewModels;
using System.Collections.Generic;

namespace Domain.Room
{
    public interface IRoomService
    {
        RoomModel GetRoomModel(int roomId);
        RoomModel GetRoomModelByRoomName(string roomName);
        List<RoomModel> GetRoomModelsByRoomIds(List<int> roomIds);
        IList<RoomViewModel> GetRoomModels(SearchRoomModel searchRoomModel);
    }
}
