using Backend.DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Context
{
    public interface IDataContext
    {
        public DbSet<CountingData> countingDatas { get; set; }
    }
}
