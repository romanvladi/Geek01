using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01

            Console.Title = "Анкета";

            Console.Write("Введите имя: ");
            string str1 = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string str2 = Console.ReadLine();

            Console.Write("Введите возраст: ");
            string str3 = Console.ReadLine();

            Console.Write("Введите рост: ");
            string str4 = Console.ReadLine();

            Console.Write("Введите вес: ");
            string str5 = Console.ReadLine();

            Console.WriteLine(str1 + " " + str2 + " " + str3 + " " + str4 + " " + str5);
            Console.WriteLine("{0} {1} {2} {3} {4}", str1, str2, str3, str4, str5);
            Console.WriteLine($"{str1} {str2} {str3} {str4} {str5}");

            Console.ReadLine();
            Console.Clear();

            #endregion

            #region 02
            Console.Title = "Индекс массы тела";

            Console.Write("Введите вес человека: ");
            string s1 = Console.ReadLine();

            Console.Write("Введите рост человека: ");
            string s2 = Console.ReadLine();

            try
            {
                double m = Convert.ToDouble(s1);
                double h = Convert.ToDouble(s2);

                double l = m / (Math.Pow(h, 2));

                Console.WriteLine($"{l}");
            }
            catch { }

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region 03 (a)
            Console.Title = "Расстояние между точками (процедура)";

            Console.Write("Введите координату (x) точки 1: ");
            string x1 = Console.ReadLine();

            Console.Write("Введите координату (y) точки 1: ");
            string y1 = Console.ReadLine();

            Console.Write("Введите координату (x) точки 2: ");
            string x2 = Console.ReadLine();

            Console.Write("Введите координату (y) точки 2: ");
            string y2 = Console.ReadLine();

            try
            {
                double dx1 = Convert.ToDouble(x1);
                double dy1 = Convert.ToDouble(y1);
                double dx2 = Convert.ToDouble(x2);
                double dy2 = Convert.ToDouble(y2);

                double r = Math.Sqrt(Math.Pow(dx2 - dx1, 2) + Math.Pow(dy2 - dy1, 2));

                Console.WriteLine($"{r:F2}");
            }
            catch { }

            Console.ReadLine();
            Console.WriteLine("/////////// Расстояние между точками (метод) ///////////");
            #endregion

            #region 03 (b)
            Console.Title = "Расстояние между точками (метод)";

            Distance(x1, y1, x2, y2);

            Console.ReadLine();
            Console.Clear();
            #endregion
        }

        static void Distance(string x1, string y1, string x2, string y2)
        {
            try
            {
                double ddx1 = Convert.ToDouble(x1);
                double ddy1 = Convert.ToDouble(y1);
                double ddx2 = Convert.ToDouble(x2);
                double ddy2 = Convert.ToDouble(y2);

                double r = Math.Sqrt(Math.Pow(ddx2 - ddx1, 2) + Math.Pow(ddy2 - ddy1, 2));

                Console.WriteLine($"{r:F2}");
            }
            catch { }
        }
    }
}