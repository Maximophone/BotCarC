using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCar
{
    class Map
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public List<double> probamap { get; private set;}
        public List<bool> snapmap { get { return probamap.Select(x => x > 0.5).ToList(); } private set { snapmap = value; } }
        public List<int> clearancemap { get { return getClearancemap(); } private set { clearancemap = value; } }


        public Map(int w, int h)
        {
            width = w;
            height = h;
            probamap = new List<double>(new double[w * h]);
        }

        public Map(int w, int h, List<double> pmap)
        {
            width = w;
            height = h;
            probamap = pmap;
        }

        public double probij(int i, int j)
        {
            return probamap[i * width + j];
        }

        public bool snapij(int i, int j)
        {
            return snapmap[i * width + j];
        }
        public int clearij(int i, int j)
        {
            return clearancemap[i * width + j];
        }

        public int clearij(int i, int j, List<int> clrmap)
        {
            return clrmap[i * width + j];
        }

        public void setij(int i, int j, double p)
        {
            probamap[i * width + j] = p;
        }

        private List<int> getClearancemap()
        {
            List<int> clmap = new List<int>();
            for (int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                {
                    int clearance = 0;
                    while(true)
                    {
                        if(clearance >= width - j) break;
                        if(clearance >= height - i) break;
                        if (!testClearance(clearance + 1, i, j)) break;
                        clearance++;
                    }
                    clmap.Add(clearance);
                }
            }
            return clmap;
        }

        private bool testClearance(int clearance, int i, int j)
        {
            int k, l;
            bool clear = true;
            for (k = 0; k < clearance; ++k)
            {
                for (l = 0; l < clearance; ++l)
                {
                    clear &= !snapij(i + k, j + l);
                }
            }
            return clear;
        }
    }
}
