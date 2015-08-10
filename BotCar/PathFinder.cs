using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCar
{
    class PathFinder
    {
        public Map map { get; private set; }
        public PathFinder(Map m)
        {
            map = m;
        }

        public List<int> aStar(int startI, int startJ, int endI, int endJ, int clearance)
        {

        }

        public List<int> computeHeuristic(int endI, int endJ)
        {
            List<double> heuristicmap = new List<double>();
            for(int i = 0; i < map.height; ++i)
            {
                for(int j = 0; j < map.width; ++j)
                {
                    heuristicmap.Add(dist(i, j, endI, endJ));
                }
            }
            return heuristicmap;
        }

        public double dist(int startI, int startJ, int endI, int endJ)
        {
            return Math.Sqrt((startI - endI) * (startI - endI) + (startJ - endJ) * (startJ - endJ));
        }
    }
}
