using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Context
{
    public class DBSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Db { get; set; }
        public string GetConnectionString()
        {
            return "Host=" + Host + ":" + Port + ";Username=" + User + ";Password=" + Password + ";Database=" + Db;
        }
    }
}
