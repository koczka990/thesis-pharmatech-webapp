using Backend.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Repositories.Interfaces
{
    public interface IStatDataRepository
    {
        public void Create(StatData countingData);
        public void Create(List<StatData> countingData);
        public StatData Get(int id);
        public List<StatData> GetAll();
        public List<StatData> GetBetween(DateTime fromTime, DateTime toTime);
    }
}
