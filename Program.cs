using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1
{
    class Program
    {
        static void NonNegativeInteger(ref int width, ref int height)//проверка высоты и ширины
        {
            while (height <= 0 || width <= 0)
            {
                Console.WriteLine("Ширина и высота должны быть больше 0");
                Console.WriteLine("Ширина:"); width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Высота:"); height = Convert.ToInt32(Console.ReadLine());
            }
        }
        static void Main(string[] args)   
        {
            int width, height, x, y;
            bool s = true;     
            Console.WriteLine("Введите координаты:");
            Console.Write("x="); x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y="); y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ширина:"); width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Высота:"); height = Convert.ToInt32(Console.ReadLine());
            NonNegativeInteger(ref width, ref height);
            Console.WriteLine("ширина {0};высота {1}",width, height);
            Rectangles rec = new Rectangles(width, height, x, y);
            while (s)
            {
                Console.WriteLine("Выберите действие\n" +
                    "0. Завершить программу\n1. Переместить прямоугольник\n2. Изменить размер\n" +
                "3. Построить прямоугольник, содержащий два заданных прямоугольника\n" +
                "4. Пересечение с другим прямоугольником");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 0:
                        s = false;
                        break;
                    case 1: //перемещение
                        Console.WriteLine("Введите координаты:");
                        Console.Write("x="); x = Convert.ToInt32(Console.ReadLine()); 
                        Console.Write("y="); y = Convert.ToInt32(Console.ReadLine());
                        rec.Moving(x, y);
                        rec.GetRec();
                        break;
                    case 2: //размер
                        Console.WriteLine("Введите новую ширину:"); width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите новую высота:"); height = Convert.ToInt32(Console.ReadLine());
                        NonNegativeInteger(ref width, ref height);
                        rec.Resize(width, height);
                        rec.GetRec();
                        break;
                    case 3://2 в 1
                        Console.WriteLine("Введите координаты второго прямоугольника:");
                        Console.Write("x="); x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y="); y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ширина:");  width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Высота:");  height = Convert.ToInt32(Console.ReadLine());
                        Rectangles rec2 = new Rectangles(width, height, x, y);
                        rec.MinRec(rec.width, rec.height, rec.x, rec.y, rec2.width, rec2.height, rec2.x, rec2.y);
                        break;
                    case 4: //пересечение 
                        Console.WriteLine("Введите координаты второго прямоугольника:");
                        Console.Write("x="); x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y="); y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ширина:"); width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Высота:"); height = Convert.ToInt32(Console.ReadLine());
                        Rectangles rec3 = new Rectangles(width, height, x, y);
                        rec3.Intersection(rec.width, rec.height, rec.x, rec.y, rec3.width, rec3.height, rec3.x, rec3.y);
                        rec3.GetRec();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}