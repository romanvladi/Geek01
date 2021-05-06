using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp02
{
    class Program
    {
        // ФИО - Ноготушкин Роман Маркович

        static void Main(string[] args)
        {
            #region Task01
            /*
             * Написать метод, возвращающий минимальное из трёх чисел.
             */
            Console.WriteLine("Минимальное число: " + Task01());
            Console.ReadLine();
            #endregion 

            #region Task02
            /*
             * Написать метод подсчета количества цифр числа.
             */
            Console.WriteLine("Количество цифр числа: " + Task02());
            Console.ReadLine();
            #endregion

            #region Task03
            /*
             * С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
             */
            Console.WriteLine("Сумма нечетных положительных чисел: " + Task03());
            Console.ReadLine();
            #endregion

            #region Task04
            /*
             * Реализовать метод проверки логина и пароля.
             * На вход метода подается логин и пароль.
             * На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
             * Используя метод проверки логина и пароля,
             * написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
             * С помощью цикла do while ограничить ввод пароля тремя попытками.
             */
            Console.WriteLine(Task04());
            Console.ReadLine();
            #endregion

            #region Task05_a
            /*
             * Написать программу, которая запрашивает массу и рост человека,
             * ычисляет его индекс массы и сообщает,
             * нужно ли человеку похудеть, набрать вес или всё в норме.
             */
            //https://cmpmos.ru/vychislenie-indeksa-massy-tela-onlajn/
            Task05_a();
            Console.ReadLine();
            #endregion

            #region Task05_b
            /*
             * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса
             */
            //https://cmpmos.ru/vychislenie-indeksa-massy-tela-onlajn/
            Task05_b();
            Console.ReadLine();
            #endregion

            #region Task06
            /*
             * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
             * «Хорошим» называется число, которое делится на сумму своих цифр.
             * Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
             */
            Task06();
            Console.ReadLine();
            #endregion

            #region Task07_a
            /*
            //Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
            */
            List<int> a = Task07_Input();
            int min = a.Min();
            int max = a.Max();
            Task07_a(min, max);
            Console.ReadLine();
            #endregion

        }

        static List<int> Task01_Input()
        {
            List<int> nnn = new List<int>();

            Console.Write("Введите первое число: ");
            string s1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string s2 = Console.ReadLine();
            Console.Write("Введите третье число: ");
            string s3 = Console.ReadLine();

            try
            {
                nnn.Add(int.Parse(s1));
                nnn.Add(int.Parse(s2));
                nnn.Add(int.Parse(s3));
            }
            catch { }

            return nnn;
        }
        static int Task01()
        {
            Console.Title = "Минимальное число";

            return Task01_Input().Min();
        }
        static int Task02()
        {
            Console.Clear();
            Console.Title = "Количество цифр числа";

            Console.Write("Введите  число: ");
            string s1 = Console.ReadLine();
            int c = s1.ToArray().Count();
            return c;
        }
        static int Task03()
        {
            Console.Clear();
            Console.Title = "Сумма нечетных положительных чисел";

            int c;
            int sum = 0;

            do
            {
                Console.Write("Введите  число: ");
                c = int.Parse(Console.ReadLine());
                if (c % 2 != 0)
                {
                    sum += c;
                }
            }
            while (c!=0);

            return sum;
        }
        static bool Task04_Input()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            if (login == "root" && password == "GeekBrains")
            {
                return true;
            }
            else { return false; }
        }
        static string Task04()
        {
            Console.Clear();
            Console.Title = "Авторизация";

            int c = 0;
            string message = "";
            do
            {
                if (Task04_Input() == true)
                {
                    message = "Программа пропускает дальше";
                    break;
                }
                else 
                {
                    c += 1;
                    Console.WriteLine("Логин и пароль не корректны");
                    Console.WriteLine($"Осталось попыток ввода:  {3-c}");
                }
            }
            while (c < 3);
            return message;
        }
        static void Task05_a()
        {
            Console.Clear();
            Console.Title = "Индекс массы тела";

            Console.Write("Введите массу человека в кг: ");
            string sM = Console.ReadLine();
            Console.Write("Введите рост человека в метрах: ");
            string sH = Console.ReadLine();

            try 
            {
                double m = double.Parse(sM);
                double h = double.Parse(sH);

                double iMT = m / (Math.Pow(h, 2));

                if (iMT < 18.5)
                {
                    Console.WriteLine("Необходимо набрать вес");
                }
                else if (iMT >= 18.5 && iMT <= 24.99)
                {
                    Console.WriteLine("Вес в норме");
                }
                else { Console.WriteLine("Необходимо сбросить вес"); }

            }
            catch { }

        }
        static void Task05_b()
        {
            Console.Clear();
            Console.Title = "Индекс массы тела v2";

            Console.Write("Введите массу человека в кг: ");
            string sM = Console.ReadLine();
            Console.Write("Введите рост человека в метрах: ");
            string sH = Console.ReadLine();

            try
            {
                double m = double.Parse(sM);
                double h = double.Parse(sH);

                double iMT = m / (Math.Pow(h, 2));

                if (iMT < 18.5)
                {
                    double dm = (Math.Pow(h, 2) * 18.5) - m;
                    Console.WriteLine($"Необходимо набрать вес: {dm} кг");
                }
                else if (iMT >= 18.5 && iMT <= 24.99)
                {
                    Console.WriteLine("Вес в норме");
                }

                else 
                {
                    double dm = m - (Math.Pow(h, 2) * 24.99);
                    Console.WriteLine($"Необходимо сбросить вес: {dm} кг "); 
                }

            }
            catch { }
        }
        static void Task06()
        {
            Console.Clear();
            Console.Title = "Количество хороших чисел";

            Console.Write("Введите число в диапазоне от 1 до 1 000 000 000:  ");          

            try
            {
                int c = int.Parse(Console.ReadLine());

                long ticks = DateTime.Now.Ticks;

                int count = 0;

                for (int i = 1; i <= c; i++)
                {
                    int sum = 0;

                    foreach (char ch in Convert.ToString(i).ToArray())
                    {
                        sum = sum + Convert.ToInt32(Convert.ToString(ch));
                    }

                    if (i % sum == 0)
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);

                ticks = DateTime.Now.Ticks - ticks;
                Console.WriteLine(ticks);
            }
            catch { }
            
        }
        static List<int> Task07_Input()
        {
            Console.Clear();
            Console.Title = "Рекурсивный вывод";

            List<int> n = new List<int>();

            Console.Write("Введите число А:  ");
            string s1 = Console.ReadLine();
            Console.Write("Введите число Б:  ");
            string s2 = Console.ReadLine();

            try
            {
                n.Add(int.Parse(s1));
                n.Add(int.Parse(s2));
            }
            catch
            { }
            return n;
        }
        static void Task07_a(int min, int max)
        {
            Console.WriteLine(min);
            if (min < max)
            {
                Task07_a(min + 1, max);
            }
        }
    }
}
