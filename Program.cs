using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1
{
    class Program
    {
        static void NonNegativeNumber(ref double width, ref double height)//проверка высоты и ширины
        {
            while (height <= 0 || width <= 0)
            {
                Console.WriteLine("Ширина и высота должны быть больше 0");
                Console.WriteLine("Ширина:"); width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Высота:"); height = Convert.ToDouble(Console.ReadLine());
            }
        }
        static void Main(string[] args)   
        {
            int x, y;
            double width, height;
            bool s = true;     
            Console.WriteLine("Введите координаты:");
            Console.Write("x="); x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y="); y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ширина:"); width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Высота:"); height = Convert.ToDouble(Console.ReadLine());
            NonNegativeNumber(ref width, ref height);
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
                        Console.WriteLine("1. Увеличить\n2. Уменьшить");
                        int  re= Convert.ToInt32(Console.ReadLine());
                        switch (re)
                        {
                            case 1:
                                Console.WriteLine("Введите во сколько раз увеличить прямоугольник:");
                                while (true)
                                {
                                    double inc = Convert.ToDouble(Console.ReadLine());
                                    if (inc<0){
                                        continue;
                                    }
                                    rec.Resize(width, height, inc);
                                    break;
                                }
                                break;
                            case 2:
                                Console.WriteLine("Введите во сколько раз уменьшить прямоугольник:");
                                while (true)
                                {
                                    double red = Convert.ToDouble(Console.ReadLine());
                                    if (red < 0)
                                    {
                                        continue;
                                    }
                                    red = 1 / red;
                                    rec.Resize(width, height, red);
                                    break;
                                }
                                break;
                            default:
                                break;

                        }
                        rec.GetRec();
                        break;
                    case 3://2 в 1
                        Console.WriteLine("Введите координаты второго прямоугольника:");
                        Console.Write("x="); x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y="); y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ширина:");  width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Высота:");  height = Convert.ToInt32(Console.ReadLine());
                        Rectangles rec2 = new Rectangles(width, height, x, y);
                        rec.MinRec(rec.Width, rec.Height, rec.X, rec.Y, rec2.Width, rec2.Height, rec2.X, rec2.Y);
                        break;
                    case 4: //пересечение 
                        Console.WriteLine("Введите координаты второго прямоугольника:");
                        Console.Write("x="); x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y="); y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ширина:"); width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Высота:"); height = Convert.ToInt32(Console.ReadLine());
                        Rectangles rec3 = new Rectangles(width, height, x, y);
                        rec3.Intersection(rec.Width, rec.Height, rec.X, rec.Y, rec3.Width, rec3.Height, rec3.X, rec3.Y);
                        rec3.GetRec();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
