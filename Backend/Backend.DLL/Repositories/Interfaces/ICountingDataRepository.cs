using Backend.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Repositories.Interfaces
{
    public interface ICountingDataRepository
    {
        public void Create(CountingData countingData);
        public void Create(List<CountingData> countingData);
        public CountingData Get(int id);
        public List<CountingData> GetAll();
        public List<CountingData> GetBetween(DateTime fromTime, DateTime toTime);
        public CountingData GetOldest();
        public CountingData GetNewest();
    }
}
