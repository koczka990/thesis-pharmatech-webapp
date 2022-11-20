using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Models
{
    public class CountingData
    {
        public int CountingDataId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int TotalCount { get; set; }
        public int JoCount { get; set; }
        public int RepedtCount { get; set; }
        public int OlajosCount { get; set; }
        public int TorottSzelCount { get; set; }
    }
}
