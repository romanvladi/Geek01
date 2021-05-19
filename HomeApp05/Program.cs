using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeApp05
{
    // Ноготушкин Роман Маркович
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1a
            /*
             * Создать программу, которая будет проверять корректность ввода логина.
             * Корректным логином будет строка от 2 до 10 символов,
             * содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
             * а) без использования регулярных выражений;
             */
            Console.Title = "Задача 1a";
            int z = 0;
            do
            {
                int check = 0;
                Console.Write("Введите логин: ");
                string log = Console.ReadLine();
                if (log.Length > 1 && log.Length < 11 && char.GetUnicodeCategory(log[0]) != System.Globalization.UnicodeCategory.DecimalDigitNumber)
                {
                    for (int i = 0; i < log.Length; i++)
                    {
                        if (log[i] >= '0' && log[i] <= '9' ||
                            log[i] >= 'A' && log[i] <= 'Z' ||
                            log[i] >= 'a' && log[i] <= 'z')
                        {
                            check++;
                        }
                        else { Console.WriteLine("Формат ввода логина не корректен"); break; }
                    }

                }
                else { Console.WriteLine("Формат ввода логина не корректен"); }
                if (check == log.Length)
                {
                    Console.WriteLine("Формат ввода логина корректен!");
                    z = 1;
                }
            }
            while (z == 0);
            Console.ReadKey();
            #endregion

            #region Task 1b
            /*
             * Создать программу, которая будет проверять корректность ввода логина.
             * Корректным логином будет строка от 2 до 10 символов,
             * содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
             * б) **с использованием регулярных выражений.
             */
            Console.Title = "Задача 1b";
            bool Res = false;
            Regex regex = new Regex(@"^[a-zA-Z]{1}[0-9a-zA-Z]{2,10}$");
            do
            {
                int check = 0;
                Console.Write("Введите логин: ");
                Res = regex.IsMatch(Console.ReadLine());
                if (Res == false)
                { Console.WriteLine("Формат ввода логина не корректен"); }
            }
            while (Res == false);
            Console.WriteLine("Формат ввода логина корректен!");
            Console.ReadKey();
            #endregion

            #region Task 2
            /*
             * Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
             * а) Вывести только те слова сообщения, которые содержат не более n букв.
             * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
             * в) Найти самое длинное слово сообщения.
             * г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
             */
            //--------Ввод-----------------------------------------
            Console.Clear();
            Console.Title = "Задача 2";
            Console.Write("Введите сообщение: "); // Пример строки: Мама мыла раму до сих пор.
            string a = Console.ReadLine();
            //--------Metod_A--------------------------------------
            int n;
            do
            {
                Console.Write("Введите размер слова: ");
                int.TryParse(Console.ReadLine(), out n);
            }
            while (n == 0);
            Message.Metod_A(a, n);
            Console.ReadKey();
            //--------Metod_B--------------------------------------
            Console.Write("Введите последнюю букву слова: ");
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine(Message.Metod_B(a, c));
            Console.ReadKey();
            //--------Metod_C--------------------------------------
            Console.WriteLine("Cамое длинное(первое) слово сообщения: " + Message.Metod_С(a));
            Console.ReadKey();
            //--------Metod_E--------------------------------------
            Console.WriteLine("Cтрока из самых длинных слов: " + Message.Metod_E(a));
            Console.ReadKey();
            #endregion


        }
    }
    public static class Message
    {
        #region Методы класса
        /// <summary>
        /// Вывести только те слова сообщения, которые содержат не более n букв.
        /// </summary>
        /// <param name="s">Строка для обработки</param>
        /// <param name="n">Количество букв</param>
        public static void Metod_A(string s, int n)
        {
            char[] separators = { '.', ',', ' ', '?', '!', '-', '"', ';',':'};
            string[] stringArr = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string i in stringArr)
            {
                if (i.Length <= n)
                {
                    Console.WriteLine(i);
                }
            }
        }
        /// <summary>
        /// Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// </summary>
        /// <param name="s">Строка для обработки</param>
        /// <param name="c">Символ</param>
        /// <returns></returns>
        public static string Metod_B(string s, char c)
        {
            string result = "";
            int count = 0;
            int word = 0;
            char[] separators = { '.', ',', ' ', '?', '!', '-', '"', ';', ':' };
            string[] stringArr = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string i in stringArr)
            {
                if (i[i.Length - 1] != c)
                { count++; }
            }
            foreach (string i in stringArr)
            {
                if (i[i.Length - 1] != c)
                {
                    word++;
                    if (word == 1) { result = i; }
                    else if (word == count) { result = result + " " + i +"."; }
                    else { result = result + " " + i; }
                }
            }
            return result;
        }
        /// <summary>
        /// Найти самое длинное слово сообщения.
        /// </summary>
        /// <param name="s">Строка для обработки</param>
        /// <returns></returns>
        public static string Metod_С(string s)
        {
            int max=0;
            string word = "";
            char[] separators = { '.', ',', ' ', '?', '!', '-', '"', ';', ':' };
            string[] stringArr = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string i in stringArr)
            {
                if (i.Length > max)
                {
                    max = i.Length;
                    word = i;
                }
            }
            return word;
        }
        /// <summary>
        /// Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        /// </summary>
        /// <param name="s">Строка для обработки</param>
        /// <returns></returns>
        public static string Metod_E(string s)
        {
            int max=0;
            int count = 0;
            char[] separators = { '.', ',', ' ', '?', '!', '-', '"', ';', ':' };
            string[] stringArr = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string i in stringArr)
            {
                if (i.Length > max)
                {
                    max = i.Length;
                }
            }
            foreach (string i in stringArr)
            {
                if (i.Length == max)
                {
                    count++;
                }
            }

            StringBuilder stringBilder = new StringBuilder((count*max)+(count*1));
            foreach (string i in stringArr)
            {
                if (i.Length == max)
                {
                    stringBilder.Append(i + " ");
                }
            }
            return stringBilder.ToString();
        }
        #endregion
    }

}
