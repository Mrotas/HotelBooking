using DataAccess.Dao.Criteria;
using DataAccess.Dao.Interfaces;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao
{
    public class RoomOptionDao : IRoomOptionDao
    {
        public RoomOption GetRoomOptionByRoomId(int roomId)
        {
            using (var db = new HotelBookingDb())
            {
                RoomOption roomOption = db.RoomOption.Single(x => x.RoomId == roomId);
                return roomOption;
            }
        }

        public IList<RoomOption> GetRoomOptionsByRoomIds(List<int> roomIds)
        {
            using (var db = new HotelBookingDb())
            {
                List<RoomOption> roomOptions = db.RoomOption.Where(x => roomIds.Contains(x.RoomId)).ToList();
                return roomOptions;
            }
        }

        public IList<RoomOption> GetRoomOptions(RoomOptionDaoCriteria criteria)
        {
            using (var db = new HotelBookingDb())
            {
                List<RoomOption> roomOptions = db.RoomOption.ToList();
                if (criteria.AirConditioning)
                {
                    roomOptions = roomOptions.Where(x => x.AirConditioning == true).ToList();
                }
                if (criteria.Balcony && roomOptions.Count > 1)
                {
                    roomOptions = roomOptions.Where(x => x.Balcony == true).ToList();
                }
                if (criteria.ChildBed && roomOptions.Count > 1)
                {
                    roomOptions = roomOptions.Where(x => x.ChildBed == true).ToList();
                }
                if (criteria.WiFi && roomOptions.Count > 1)
                {
                    roomOptions = roomOptions.Where(x => x.WiFi == true).ToList();
                }

                return roomOptions;
            }
        }

        public IList<RoomOption> GetAllRoomOptions()
        {
            using (var db = new HotelBookingDb())
            {
                List<RoomOption> roomOptions = db.RoomOption.ToList();
                return roomOptions;
            }
        }
    }
}
