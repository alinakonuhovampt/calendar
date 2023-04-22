using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CallCalendar.Data
{
    static class LoadSaveHelper
    {
        public static void SaveUserChoose(UserChoose choose)
        {
            string filename = System.AppDomain.CurrentDomain.BaseDirectory + "/saves/" + choose.date.ToString("dd-MM-yyyy") + ".json";

            if (choose.items.Count == 0)
            {
                if (File.Exists(filename))
                    File.Delete(filename);

                return;
            }

            string json = JsonSerializer.Serialize(choose.items);

            if (!Directory.Exists(filename))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/saves");
            }
            File.WriteAllText(filename, json);
        }

        public static UserChoose LoadUserChoose(DateOnly date)
        {
            string filename = System.AppDomain.CurrentDomain.BaseDirectory + "/saves/" + date.ToString("dd-MM-yyyy") + ".json";

            UserChoose choose = new (date);

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);

                choose.items = JsonSerializer.Deserialize<List<string>>(json) ?? new ();
            }

            return choose;
        }
    }
}