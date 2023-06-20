using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Work
{
    public class NiceList
    {
        public string tempr;
        public string vlazn;
        public string oshys;
        public string desc;
        public DateTime time;

        public NiceList(string v1, string v2, string v3, string v4, DateTime time1)
        {
            tempr = v1;
            vlazn = v2;
            oshys = v3;
            desc = v4;            
            time = time1;

        }
    }
}
