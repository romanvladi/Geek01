using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeApp04
{
    // ФИО - Ноготушкин Роман Маркович

    class Program
    {
        static void Main(string[] args)
        {
            #region Task01
            /*
             * Дан целочисленный массив из 20 элементов.
             * Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
             * Заполнить случайными числами. 
             * Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
             * В данной задаче под парой подразумевается два подряд идущих элемента массива.
             */

            Console.Title = "Задача 1";
            int[] array = new int[20];
            Random rnd = new Random();
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10000, 10000);

                if (array[i] % 3 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write($"{array[i]}");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($"{array[i]}");
                }

                if (i % 2 != 0)
                {
                    if (array[i] % 3 == 0 && array[i - 1] % 3 != 0 || array[i] % 3 != 0 && array[i - 1] % 3 == 0)
                    {
                        count++;
                    }
                }
                else if (i % 2 == 0 && i != 0)
                {
                    if (array[i] % 3 == 0 && array[i - 1] % 3 != 0 || array[i] % 3 != 0 && array[i - 1] % 3 == 0)
                    {
                        count++;
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($" ");
            }

            Console.WriteLine();
            Console.WriteLine($"Количество найденных пар: {count}");

            Console.ReadKey();

            #endregion 

            #region Task02
            /*
             * Реализуйте задачу 1 в виде статического класса StaticClass.
             * Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1.
             * Реализуйте задачу 1 в виде статического класса StaticClass.
             * Добавьте статический метод для считывания массива из текстового файла. 
             * Метод должен возвращать массив целых чисел.
             * Реализуйте задачу 1 в виде статического класса StaticClass.
             * Добавьте обработку ситуации отсутствия файла на диске.
             */
            Console.Clear();
            Console.Title = "Задача 2";

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "ArraySample.txt";

            StaticClass.WriteFileRandomNumber(filePath);

            StaticClass.Search(StaticClass.GetArrayFromFile(filePath));

            Console.ReadKey();

            #endregion

            #region Task03
            /*
             * Дописать класс для работы с одномерным массивом.
             * Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
             * оздать свойство Sum, которое возвращает сумму элементов массива,
             * метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),
             * метод Multi, умножающий каждый элемент массива на определённое число,
             */

            //--------------Ввод данных----------------

            Console.Clear();
            Console.Title = "Задача 3";
            int x1;
            int x2;
            int x3;
            bool b2;
            bool b3;
            do 
            {
                Console.Write("Введите размерность массива: ");
                int.TryParse(Console.ReadLine(), out x1);
            }
            while (x1==0);
            do
            {
                Console.Write("Введите начальное число: ");
                b2 = int.TryParse(Console.ReadLine(), out x2);
            }
            while (b2 == false);
            do
            {
                Console.Write("Введите интервал заполнения: ");
                b3 = int.TryParse(Console.ReadLine(), out x3);
            }
            while (b3 == false);

            //-----------------------------------------

            ArrayClass arrayClass = new ArrayClass(x1, x2, x3);
            Console.Write("Массив А: ");
            for (int i = 0; i < arrayClass.GetLenght; i++)
            {
                
                Console.Write(arrayClass[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

            //-----------------------------------------

            Console.WriteLine($"Сумма элементов массива: {arrayClass.Sum}");

            //-----------------------------------------

            Console.Write("Новый массив обратных знаков: ");
            for (int i = 0; i < x1; i++)
            {
                Console.Write(arrayClass.Inverse()[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

            //-----------------------------------------

            int t;
            bool b4;
            do
            {
                Console.Write("Введите множитель элементов массива: ");
                b4 = int.TryParse(Console.ReadLine(), out t);
            }
            while (b4 == false);

            arrayClass.Multi(t);

            Console.Write("Массив А: ");
            for (int i = 0; i < arrayClass.GetLenght; i++)
            {
                Console.Write(arrayClass[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

            //-----------------------------------------

            int[] z = { 3, 7, 7, 6, 5, 1 };
            ArrayClass aC = new ArrayClass(z);

            Console.WriteLine("Массив В: { 3, 7, 7, 6, 5, 1 }");
            Console.Write("Количество максимальных элементов массива: ");

            Console.WriteLine(aC.MaxCount);

            //-----------------------------------------

            Console.ReadKey();
            #endregion

        }
    }

    static class StaticClass
    {
        /// <summary>
        /// Статический метод для поиска пар
        /// </summary>
        /// <param name="array"></param>
        public static void Search(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 3 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write($"{array[i]}");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($"{array[i]}");
                }

                if (i % 2 != 0)
                {
                    if (array[i] % 3 == 0 && array[i - 1] % 3 != 0 || array[i] % 3 != 0 && array[i - 1] % 3 == 0)
                    {
                        count++;
                    }
                }
                else if (i % 2 == 0 && i != 0)
                {
                    if (array[i] % 3 == 0 && array[i - 1] % 3 != 0 || array[i] % 3 != 0 && array[i - 1] % 3 == 0)
                    {
                        count++;
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($" ");
            }

            Console.WriteLine();
            Console.WriteLine($"Количество найденных пар: {count}");
        }

        /// <summary>
        /// Статический метод для считывания массива из текстового файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int[] GetArrayFromFile(string filePath)
        {
            int dim = 0;

            try 
            {
                StreamReader reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    dim += 1;
                    reader.ReadLine();
                }
                reader.Close();

                int[] array = new int[dim];
                int count = 0;
                StreamReader reader2 = new StreamReader(filePath);
                while (!reader2.EndOfStream)
                {
                    array[count] = int.Parse(reader2.ReadLine());
                    count++;
                }
                return array;
            }
            catch 
            {
                throw new Exception();
            }

            
        }

        /// <summary>
        /// Статический метод для записи массива рандомных чисел
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteFileRandomNumber(string filePath)
        {
            int c;
            do
            {
                Console.Write("Введите размерность для массива рандомных чисел: ");
                int.TryParse(Console.ReadLine(), out c); 
            }
            while (c==0);

            Random r = new Random();
            StreamWriter writer = new StreamWriter(filePath);

            for (int i = 0; i < c; i++)
            {
                writer.WriteLine(r.Next(-10000, 10000));
            }
            writer.Close();
        }
    }

    class ArrayClass
    {
        private int[] arr;

        /// <summary>
        /// Конструктор класса на основе массива целых чисел
        /// </summary>
        /// <param name="arr"></param>
        public ArrayClass(int[] arr) 
        {
            this.arr = arr;
        }

        /// <summary>
        /// Конструктор создания массива с заданной размерностью, начальным числом и интервалом заполнения
        /// </summary>
        /// <param name="a">Размерность массива</param>
        /// <param name="b">Начальное число</param>
        /// <param name="c">Интервал заполнения</param>
        public ArrayClass(int a, int b, int c)
        {
            this.arr = new int[a];
            for (int i = 0; i < a; i++)
            {
                arr[i] = b;
                b += c;
            }
        }

        /// <summary>
        /// Метод, возвращающий новый массив с измененными знаками у всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
            int[] a = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                a[i] = arr[i] * -1;
            }
            return a;
        }

        /// <summary>
        /// Метод, умножающий каждый элемент массива на определённое число
        /// </summary>
        /// <param name="t"></param>
        public void Multi(int t)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                this.arr[i] = arr[i] * t;
            }
        }

        /// <summary>
        /// Свойство. Возврат и назначение элемента массива по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        /// <summary>
        /// Свойство. Возврат сумму элементов массива
        /// </summary>
        public int Sum
        {
            get 
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum; 
            }
        }

        /// <summary>
        /// Свойство. Длинна массива
        /// </summary>
        public int GetLenght
        {
            get { return arr.Length; }
        }
            

        /// <summary>
        /// Свойство. возвращающее количество максимальных элементов.
        /// </summary>
        public int MaxCount
        {
            get 
            {
                int count = 0;
                int max = arr[0];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                    if (arr[i] == max)
                    {
                        count += 1;
                    }
                }
                return count; 
            }
        }
    }
}
