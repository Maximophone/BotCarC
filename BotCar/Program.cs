using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Double> doublemap = Tools.parseCSVmap("../../map.csv");
            Map m = new Map(4,4, doublemap);
            IEnumerable<bool> l = m.probamap.Select(x => x > 0.5);
            Console.WriteLine(m.snapmap[0]);
            Console.WriteLine(m.snapmap[12]);
            m.setij(0, 0, 0.9);
            Console.WriteLine(m.snapmap[0]);
            Console.WriteLine(m.snapij(0,0));

            Tools.representSnapMap(m);
            Tools.representClearance(m);



            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
