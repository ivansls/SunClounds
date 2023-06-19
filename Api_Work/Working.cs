using Newtonsoft.Json;

namespace Api_Work
{
    public class Working
    {
        public static dynamic pogIn;
        public static dynamic pogCur;


        public static List<NiceList> Left_Panel(string city)
        {
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid=273fca0d7e6eb56d8c0ede4099553321&lang=ru").Result;
                string json = message.Content.ReadAsStringAsync().Result;
                pogIn = JsonConvert.DeserializeObject(json);
                DateTime t_emp = Convert.ToDateTime(pogIn.list[0].dt_txt.ToString());
                List<NiceList> voz = new List<NiceList>();
                if (t_emp.TimeOfDay > DateTime.Now.TimeOfDay)
                {
                    for (int i = 1; i < 11; i++)
                    {
                        int cel = pogIn.list[i].main.temp - 273; //перевод в цельсию
                        int cel1 = pogIn.list[i].main.feels_like - 273; //перевод в цельсию
                        voz.Add(new NiceList(cel.ToString(), pogIn.list[i].main.humidity.ToString(), cel1.ToString(), pogIn.list[i].weather[0].description.ToString()));
                    }
                    return voz;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int cel = pogIn.list[i].main.temp - 273; //перевод в цельсию
                        int cel1 = pogIn.list[i].main.feels_like - 273; //перевод в цельсию
                        voz.Add(new NiceList(cel.ToString(), pogIn.list[i].main.humidity.ToString(), cel1.ToString(), pogIn.list[i].weather[0].description.ToString()));
                    }
                    return voz;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static Cur_Weather Main_weather(string city)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=273fca0d7e6eb56d8c0ede4099553321").Result;
                string json = message.Content.ReadAsStringAsync().Result;
                pogCur = JsonConvert.DeserializeObject(json);
                int tem = pogCur.main.temp;
                tem = tem - 273;//перевод температуры
                Cur_Weather wh = new Cur_Weather(tem.ToString(), pogCur.main.feels_like.ToString(), pogCur.main.temp_min.ToString(), pogCur.main.temp_max.ToString(), pogCur.main.pressure.ToString(), pogCur.main.humidity.ToString(), pogCur.wind.speed.ToString(), pogCur.wind.deg.ToString());
                return wh;
            }
            catch (Exception ex)
            {
                return null;

            }

        }
    }
}