using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Work
{
    public class Cur_Weather
    {
        public string temp;
        public string feels;
        public string min_temp;
        public string max_temp;
        public string pressure;
        public string humidity;
        public string wind;
        public string wind2;
        public string desc;
        public string main;

        public Cur_Weather(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9,string v10)
        {
            temp = v1;
            feels = v2;
            min_temp = v3;
            max_temp = v4;
            pressure = v5;
            humidity = v6;
            wind = v7;
            wind2 = v8;
            desc = v9;
            main = v10;
        }
    }
}
