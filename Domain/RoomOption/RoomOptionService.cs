using DataAccess.Dao;
using DataAccess.Dao.Criteria;
using DataAccess.Dao.Interfaces;
using Domain.RoomOption.Models;
using System.Collections.Generic;
using System.Linq;

namespace Domain.RoomOption
{
    public class RoomOptionService : IRoomOptionService
    {
        private readonly IRoomOptionDao _roomOptionDao;

        public RoomOptionService() : this(new RoomOptionDao())
        {

        }

        public RoomOptionService(IRoomOptionDao roomOptionDao)
        {
            _roomOptionDao = roomOptionDao;
        }

        public RoomOptionModel GetRoomOptionByRoomId(int roomId)
        {
            DataAccess.Entities.RoomOption roomOption = _roomOptionDao.GetRoomOptionByRoomId(roomId);
            var roomOptionModel = new RoomOptionModel
            {
                AirConditioning = roomOption.AirConditioning,
                Balcony = roomOption.Balcony,
                ChildBed = roomOption.ChildBed,
                OnePersonBed = roomOption.OnePersonBed,
                RoomId = roomOption.RoomId,
                TwoPersonBed = roomOption.TwoPersonBed,
                WiFi = roomOption.WiFi,
            };

            return roomOptionModel;
        }

        public List<RoomOptionModel> GetRoomOptions(SearchRoomCriteria criteria)
        {
            var roomOptionCriteria = new RoomOptionDaoCriteria
            {
                AirConditioning = criteria.AirConditioning,
                Balcony = criteria.Balcony,
                ChildBed = criteria.ChildBed,
                WiFi = criteria.WiFi
            };

            IList<DataAccess.Entities.RoomOption> roomOptions = _roomOptionDao.GetRoomOptions(roomOptionCriteria);

            List<RoomOptionModel> roomOptionModels = roomOptions.Select(x => new RoomOptionModel
            {
                AirConditioning = x.AirConditioning,
                Balcony = x.Balcony,
                ChildBed = x.ChildBed,
                WiFi = x.WiFi,
                OnePersonBed = x.OnePersonBed,
                TwoPersonBed = x.TwoPersonBed,
                RoomId = x.RoomId
            }).ToList();

            return roomOptionModels;
        }

        public List<RoomOptionModel> GetRoomOptionsByRoomIds(List<int> roomIds)
        {
            IList<DataAccess.Entities.RoomOption> roomOptions = _roomOptionDao.GetRoomOptionsByRoomIds(roomIds);

            List<RoomOptionModel> roomOptionModels = roomOptions.Select(x => new RoomOptionModel
            {
                RoomId = x.RoomId,
                AirConditioning = x.AirConditioning,
                Balcony = x.Balcony,
                ChildBed = x.ChildBed,
                WiFi = x.WiFi,
                OnePersonBed = x.OnePersonBed,
                TwoPersonBed = x.TwoPersonBed
            }).ToList();

            return roomOptionModels;
        }
    }
}
