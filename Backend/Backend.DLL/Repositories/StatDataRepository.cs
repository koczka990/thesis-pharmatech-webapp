using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DLL.Context;
using Backend.DLL.Models;
using Backend.DLL.Repositories.Interfaces;

namespace Backend.DLL.Repositories
{
    public class StatDataRepository : IStatDataRepository
    {
        private DataContext dataContext { get; set; }

        public StatDataRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(StatData countingData)
        {
            dataContext.countingDatas.Add(countingData);
            dataContext.SaveChanges();
        }

        public void Create(List<StatData> countingData)
        {
            foreach (var data in countingData)
            {
                dataContext.countingDatas.Add(data);
            }
            dataContext.SaveChanges();
        }

        public CountingData Get(int id)
        {
            return dataContext.countingDatas.FirstOrDefault(x => x.CountingDataId == id);
        }
        public List<CountingData> GetAll()
        {
            var q = from m in dataContext.countingDatas select m;
            return q.ToList();
        }

        public List<CountingData> GetBetween(DateTime fromTime, DateTime toTime)
        {
            var q = from m in dataContext.countingDatas
                    where m.FromTime >= fromTime && m.ToTime <= toTime
                    select m;
            return q.ToList();
        }
    }
}
