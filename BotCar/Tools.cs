using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotCar
{
    class Tools
    {
        public static void representSnapMap(Map map)
        {
            for(int i = 0; i < map.height; ++i)
            {
                string line = "";
                for(int j = 0; j < map.width; ++j)
                {
                    line += map.snapij(i, j) ? "#" : " ";
                }
                Console.WriteLine(line);
            }
        }

        public static void representClearance(Map map)
        {
            List<int> clearancemap = map.clearancemap;
            for (int i = 0; i < map.height; ++i)
            {
                string line = "";
                for (int j = 0; j < map.width; ++j)
                {
                    line += fixStrSize(Convert.ToString(map.clearij(i, j, clearancemap)), 2);
                }
                Console.WriteLine(line);
            }
        }

        public static string fixStrSize(string s, int size)
        {
            string strTrimmed = s;
            if (size < s.Length) strTrimmed = s.Substring(0, size);
            for(int i = 0; i < size - s.Length; ++i)
            {
                strTrimmed += " ";
            }
            return strTrimmed;
        }

        public static List<double> parseCSVmap(string url)
        {
            string text = File.ReadAllText(url);
            text = text.Replace("\r\n",",");
            return parseStringMap(text);
        }

        public static List<double> parseStringMap(string strmap)
        {
            return strmap.Split(',').Select(x => Convert.ToDouble(x)).ToList();
        }
    }

}
