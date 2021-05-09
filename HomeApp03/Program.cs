using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp03
{
    //Ф.И.0 - Ноготушкин Роман Маркович
    class Program
    {
        static void Main(string[] args)
        {
            #region TASK 1a
            ///*
            // * Дописать структуру Complex, добавив метод вычитания комплексных чисел.
            // * Продемонстрировать работу структуры.
            // */
            //Console.Title = "Структуры комплексных чисел";

            //Complex_Struct com1;
            //com1.re = 5;
            //com1.im = -3;
            //Console.WriteLine($"Первое комплексное число: {com1}");

            //Complex_Struct com2;
            //com2.re = 1;
            //com2.im = 2;
            //Console.WriteLine($"Второе комплексное число: {com2}");

            //Complex_Struct com3 = com1.MinusComplexStruct(com2);
            //Console.WriteLine($"Третье комплексное число: {com3}");

            //Console.ReadKey();
            #endregion

            #region TASK 1b
            ///*
            // * Дописать класс Complex, добавив методы вычитания и произведения чисел.
            // * Проверить работу класса.
            // */
            //Console.Clear();
            //Console.Title = "Классы комплексных чисел";

            //Complex_Class complex01 = new Complex_Class(5,-3);
            //Console.WriteLine($"Первое комплексное число: {complex01}");

            //Complex_Class complex02 = new Complex_Class(1, 2);
            //Console.WriteLine($"Второе комплексное число: {complex02}");

            //Complex_Class complex03 = complex01.MinusComplexClass(complex02);
            //Console.WriteLine($"Разность комплексных чисел: {complex03}");

            //Complex_Class complex04 = complex01.GenerationComplexClass(complex02);
            //Console.WriteLine($"Произведение комплексных чисел: {complex03}");

            //Console.ReadKey();
            #endregion

            #region TASK 1c
            ///*
            // * Добавить диалог с использованием switch демонстрирующий работу класса.
            // */
            //Console.Clear();
            //Console.Title = "Два комплексных чила";
            //Console.WriteLine($"Первое комплексное число: {complex01}");
            //Console.WriteLine($"Второе комплексное число: {complex02}");
            //Console.Write("Введите операцию сложения(+), или вычетания(-)), или произведения(*): ");
            //string s;
            //do
            //{
            //    s = Console.ReadLine();
            //    switch (s)
            //    {
            //        case "+": Console.WriteLine(complex01.PlusComplexClass(complex02)); break;
            //        case "-": Console.WriteLine(complex01.MinusComplexClass(complex02)); break;
            //        case "*": Console.WriteLine(complex01.GenerationComplexClass(complex02)); break;
            //        default: Console.WriteLine("Введите еще раз"); break;
            //    }
            //}
            //while (s != "+" && s != "-" && s != "*");

            //Console.ReadKey();
            #endregion

            #region TASK 2
            ///*
            // * С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
            // * Требуется подсчитать сумму всех нечётных положительных чисел. 
            // * Сами числа и сумму вывести на экран, используя tryParse.
            // */

            //Console.Clear();
            //Console.Title = "Сумма всех нечетных положительных чисел";
            //double sum = 0;
            //double n;

            //do
            //{
            //    Console.Write("Введите число: ");
            //    bool b = double.TryParse(Console.ReadLine(), out n);
            //    if (b == true)
            //    {
            //        if (n % 2 != 0 && n > 0)
            //        {
            //            sum += n;
            //        }
            //        else { continue; }
            //    }
            //    else { n = 2; }               
            //}
            //while (n != 0);

            //Console.WriteLine($"Сумма всех нечетных положительных чисел: {sum}");
            //Console.ReadKey();
            #endregion

            #region TASK 3
            /*
             * Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
             * Предусмотреть методы сложения, вычитания, умножения и деления дробей.
             * Написать программу, демонстрирующую все разработанные элементы класса.
             * ---------------------------------------------------------------------
             * Добавить свойства типа int для доступа к числителю и знаменателю;
             * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; **
             * Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
             * Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0"); *** Добавить упрощение дробей.
             */
            Console.Clear();
            Console.Title = "Дробные числа";

            //---------Введение первой дроби---------
            bool a1;
            int ai;
            int aj;
            do
            {
                Console.Write("Введите числитель числа а: ");
                a1 = int.TryParse(Console.ReadLine(), out ai);
            }
            while (a1 == false);
            do 
            {
                Console.Write("Введите знаменатель числа а: ");
                bool a2 = int.TryParse(Console.ReadLine(), out aj); 
            }
            while (aj == 0);

            FractionalNumber a = new FractionalNumber(ai,aj);
            Console.WriteLine($"Первая дробь: {a}");

            //---------Введение второй дроби---------

            bool b1;
            int bi;
            int bj;
            do
            {
                Console.Write("Введите числитель числа b: ");
                b1 = int.TryParse(Console.ReadLine(), out bi);
            }
            while (b1 == false);
            do
            {
                Console.Write("Введите знаменатель числа b: ");
                bool b2 = int.TryParse(Console.ReadLine(), out bj);
            }
            while (bj == 0);

            FractionalNumber b = new FractionalNumber(bi, bj);
            Console.WriteLine($"Вторая дробь: {b}");

            //--------- Результаты ---------

            Console.WriteLine();

            Console.WriteLine($"Сложение дробей: {a.Plus(b)}"); 
            Console.WriteLine($"Вычетание дробей: {a.Minus(b)}"); 
            Console.WriteLine($"Умножение дробей: {a.Generation(b)}"); 
            Console.WriteLine($"Деление дробей: {a.Degree(b)}"); 


            Console.ReadKey();
            #endregion
        }
    }

    struct Complex_Struct
    {
        public double im; // Мнимая часть комплексного числа
        public double re; // действительная часть комплексного числа

        public Complex_Struct PlusComplexStruct(Complex_Struct x) // Сложение комплексных чисел
        {
            Complex_Struct y;
            y.re = re + x.re;
            y.im = im + x.im;

            return y;
        }
        public Complex_Struct MinusComplexStruct(Complex_Struct x) // Вычетание комплексных чисел
        {
            Complex_Struct y;
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }
        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
    class Complex_Class
    {
        #region состояние экземпляра класса
        private double im; // Мнимая часть комплексного числа
        private double re; // действительная часть комплексного числа
        #endregion

        #region конструкторы экземпляра класса
        public Complex_Class() { }
        public Complex_Class(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        #endregion

        #region методы экземпляра класса    
        public Complex_Class PlusComplexClass(Complex_Class x) // Сложение комплексных чисел
        {         
            Complex_Class y = new Complex_Class(re + x.re, im + x.im);
            return y;
        }
        public Complex_Class MinusComplexClass(Complex_Class x) // Вычитание комплексных чисел
        {
            Complex_Class y = new Complex_Class(re - x.re, im - x.im);
            return y;
        }
        public Complex_Class GenerationComplexClass(Complex_Class x) // Произведение комплексных чисел
        {
            Complex_Class y = new Complex_Class(re * x.re, im * x.im);
            return y;
        }
        public override string ToString() // переопределенный метод базового класса
        {           
            return $"{re} + {im}i";
        } 
        #endregion

        #region свойства экземпляра класса
        public double Re // управление или отображение состояния re
        {
            get 
            { 
                return re; 
            }
            set 
            {
                re = value;
            }
        }
        #endregion
    }
    class FractionalNumber
    {
        #region состояние экземпляра класса
        private int i; // числитель
        private int j; // знаменатель
        #endregion

        #region конструкторы экземпляра класса
        public FractionalNumber(int i, int j)
        {
            if (j != 0)
            {
                this.i = i;
                this.j = j;
            }
            else 
            {
                throw new Exception("Недопустимое значение переменной");
            }
        }
        #endregion

        #region методы экземпляра класса
        public FractionalNumber Plus(FractionalNumber x) // метод сложение дробей
        {
            FractionalNumber y = new FractionalNumber((i * x.j) + (x.i * j), j * x.j);

            for (int c = 1; c <= Math.Abs(y.i); c++)
            {
                if (y.i % c == 0 && y.j % c == 0)
                {
                    y.i = y.i / c;
                    y.j = y.j / c;
                }
            }
            return y;
        }
        public FractionalNumber Minus(FractionalNumber x) // метод вычитание дробей
        {
            FractionalNumber y = new FractionalNumber((i * x.j) - (x.i * j), j * x.j);

            for (int c = 1; c <= Math.Abs(y.i); c++)
            {
                if (y.i % c == 0 && y.j % c == 0)
                {
                    y.i = y.i / c;
                    y.j = y.j / c;
                }
            }
            return y;
        }
        public FractionalNumber Generation(FractionalNumber x) // метод умножение дробей
        {
            FractionalNumber y = new FractionalNumber(i * x.i, j * x.j);

            for (int c = 1; c <= Math.Abs(y.i); c++)
            {
                if (y.i % c == 0 && y.j % c == 0)
                {
                    y.i = y.i / c;
                    y.j = y.j / c;
                }
            }
            return y;
        }
        public FractionalNumber Degree(FractionalNumber x) // метод деления дробей
        {
            FractionalNumber y = new FractionalNumber(i * x.j, j * x.i);

            for (int c = 1; c <= Math.Abs(y.i); c++)
            {
                if (y.i % c == 0 && y.j % c == 0)
                {
                    y.i = y.i / c;
                    y.j = y.j / c;
                }
            }
            return y;
        }
        public override string ToString()
        {
            return $"{i}/{j}";
        }
        #endregion

        #region свойства экземпляра класса
        public int I
        {
            get { return i; }
            set { i = value; }
        }
        public int J
        {
            get { return j; }
            set 
            {
                if (value == 0)
                {
                    throw new Exception("Недопустимое значение переменной");
                }
                else
                {
                    j = value;
                }
            }
        }
        public double D
        {
            get 
            {
                return Convert.ToDouble(i) / Convert.ToDouble(j);
            }
        }
        #endregion
    }
}
