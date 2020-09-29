using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Rectangles
    {
        public int width, height, x, y;
        public Rectangles(int width, int height, int x, int y)
        {
            this.width = width; this.height = height; this.x = x; this.y = y;
        }
        public void Moving(int x, int y)
        {
            this.x = x; this.y = y;
        }
        public void Resize(int width, int height)
        {
            this.width = width; this.height = height;
        }
        public void MinRec(int width, int height, int x, int y, int width1, int height1, int x1, int y1)
        {
            int ymax = Math.Max(y, y1);
            int ymin = Math.Min(y - height, y1 - height1);
            int xmax = Math.Max(x + width1, x1 + width1);
            int xmin = Math.Max(x, x1);
            Console.WriteLine("Координаты полученного прямоугольника: ({0},{1}), ({2},{3}), " +
                            "({4},{5}), ({6},{7})", xmin, ymax, xmax, ymax, xmax, ymin, xmin, ymin);
        }
        public void Intersection(int width, int height, int x, int y, int width1, int height1, int x1, int y1)
        {
            int w = 0, xb = 0, ya = 0, yb = 0, h = 0;
            int yma = Math.Max(y, y1);
            int ym = Math.Min(y - height, y1 - height1);
            int xma = Math.Max(x + width, x1 + width1); //крайняя правая точка
            int xm = Math.Max(x, x1); //крайняя левая точка
            if (xma < xm)
            {
                Console.WriteLine("Прмоугольники не пересекаются");
            }
            else
            {
                if (x + width < x1 + width1)
                {
                    int xa = x + width; xb = x1;
                    w = xa - xb;
                }
                else if (x + width > x1 + width1)
                {
                    int xa = x1 + width1; xb = x;
                    w = xa - xb;
                }
                if (y <= y1 && (y - height) >= (y1 - height1))
                {
                    ya = y; yb = y - height;
                    h = ya - yb;
                }
                else if (y > y1 && (y - height) >= (y1 - height1))
                {
                    ya = y1; yb = y1 - height1;
                    h = ya - yb;
                }
            }
           
        }
        public void GetRec()
        {
            Console.WriteLine("Координаты полученного прямоугольника: ({0},{1}), ({2},{3}), " +
               "({4},{5}), ({6},{7})", x, y, x + width, y, x + width, y - height, x, y - height);
        } 
    }
}
