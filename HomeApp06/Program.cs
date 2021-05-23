using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeApp06
{
    // ФИО: Ноготушкин Роман Маркович
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            /*
             * Изменить программу вывода таблицы функции так,
             * чтобы можно было передавать функции типа double (double, double).
             * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
             */
            Console.Title = "Задача 1";

            Console.WriteLine("Таблица функции a*x^2:");

            Table(MyFunc1, -2, 1, 3);

            Console.WriteLine("Таблица функции a*sin(x):");

            Table(MyFunc2, -2, 1, 3);

            Console.ReadKey();
            #endregion

            #region Task 2
            /*
             * Модифицировать программу нахождения минимума функции так, 
             * чтобы можно было передавать функцию в виде делегата.
             * а) Сделать меню с различными функциями и представить пользователю выбор, 
             * для какой функции и на каком отрезке находить минимум. 
             * Использовать массив (или список) делегатов, 
             * в котором хранятся различные функции.
             * б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
             * Пусть она возвращает минимум через параметр (с использованием модификатора out).
             */

            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            int numb;
            double a;
            double b;
            double h;
            double res;

            do
            {
                Console.Write("Введите начальное значение аргумента функции: ");
                b1 = double.TryParse(Console.ReadLine(), out a);
            }
            while (b1==false);

            do
            {
                Console.Write("Введите конечное значение аргумента функции: ");
                b2 = double.TryParse(Console.ReadLine(), out b);
            }
            while (b2 == false);

            do
            {
                Console.Write("Введите шаг значений аргумента функции: ");
                b3 = double.TryParse(Console.ReadLine(), out h);
            }
            while (b3 == false);


            FunTask2[] arrayF = { F1, F2, F3 };

            do
            {
                Console.Write("Номер функции(1,2,3): ");
                b4 = int.TryParse(Console.ReadLine(), out numb);
                if (numb <1 || numb >3)
                {
                    b4 = false;
                }
                
            }
            while (b4 == false);

            switch (numb)
            {
                case 1: SaveFunc(arrayF[0], AppDomain.CurrentDomain.BaseDirectory + "data.bin", a, b, h);break;
                case 2: SaveFunc(arrayF[1], AppDomain.CurrentDomain.BaseDirectory + "data.bin", a, b, h); break;
                case 3: SaveFunc(arrayF[2], AppDomain.CurrentDomain.BaseDirectory + "data.bin", a, b, h); break;
            }

            SaveFunc(F1, AppDomain.CurrentDomain.BaseDirectory + "data.bin", a, b, h);


            Console.WriteLine(Load(AppDomain.CurrentDomain.BaseDirectory+"data.bin"));

            Console.WriteLine(Load2(AppDomain.CurrentDomain.BaseDirectory + "data.bin",out res));


            Console.ReadKey();
            #endregion
        }
        #region Методы выполнения Task 1
        public static void Table(FunTask1 F, double x, double a, double b)
        {
            Console.WriteLine("------- A ------ X ------ Y ------");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(x, a));
                x += 1;
            }
            Console.WriteLine("----------------------------------");
        }
        public static double MyFunc1(double x, double a)
        {
            return a * x * x;
        }
        public static double MyFunc2(double x, double a)
        {
            return a * Math.Sin(x);
        }
        #endregion

        #region Методы выполнения Task 2
        public static double F1(double x)
        {
            return x + x;
        }
        public static double F2(double x)
        {
            return x * x;
        }
        public static double F3(double x)
        {
            return x * x * x;
        }
        public static void SaveFunc(FunTask2 F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }

        public static double[] Load2(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);

            min = double.MaxValue;
            double[] arrayValue = new double[fs.Length / sizeof(double)];

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                arrayValue[i] = bw.ReadDouble();
                if (arrayValue[i] < min) min = arrayValue[i];
            }
            bw.Close();
            fs.Close();
            return arrayValue;
        }

        #endregion
    }
    /// <summary>
    /// Делегат для выполнения Task 1
    /// </summary>
    /// <param name="x"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public delegate double FunTask1(double x, double a);

    /// <summary>
    /// Делегат для выполнения Task 2
    /// </summary>
    /// <param name="x"></param>
    public delegate double FunTask2(double x);


}
