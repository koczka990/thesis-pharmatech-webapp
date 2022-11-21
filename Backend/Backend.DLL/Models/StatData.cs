using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Models
{
    public class StatData
    {
        public int StatDataId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int HibaSum { get; set; }
        public int JoSum { get; set; }
        public int RepedtSum { get; set; }
        public int OlajosSum { get; set; }
        public int TorottszelSum { get; set; }
    }
}
