using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    class Program
    {
        static void ShowList(List <double> list)
        {
            int c = 0;
            foreach (double elem in list)
            {
                c++;
                Console.WriteLine("{0}-й элемент последовательности: {1}", c, elem);
            }
        }
        static List<double> Rec(List<double> list, int N)
        {
            if (list.Count < N)
            {
                double a1 = list[list.Count - 3];
                double a2 = list[list.Count - 2];
                double a3 = list[list.Count - 1];
                double a = ((a3 + a2) / 2) - a1;    
                list.Add(a);
                Rec(list, N);
            }
            return list;
        }
        static void SubsequenceLength(List<double> list, out double lastElem, out int count)
        {
            lastElem = double.MinValue;
            count = 1;
            int secCount = 1;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > list[i - 1])
                    secCount++;
                else
                {
                    if (count < secCount)
                    {
                        count = secCount;
                        secCount = 1;
                        lastElem = list[i - 1];
                    }
                    else
                        secCount = 1;
                }
            }
        }
        static void Main(string[] args)
        {
            double a1, a2, a3;
            int N;
            bool ok;
            Console.WriteLine("Введите первый элемент последовательности: ");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out a1);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите натуральное число!");
            } while (!ok);
            Console.WriteLine("Введите второй элемент последовательности: ");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out a2);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите натуральное число!");
            } while (!ok);
            Console.WriteLine("Введите третий элемент последовательности: ");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out a3);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите натуральное число!");
            } while (!ok);
            Console.WriteLine("Введите количество элементов последовательности: ");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите натуральное число!");
                if (N <= 3)
                {
                    Console.WriteLine("Ошибка. Введите последовательность, большую 3.");
                    ok = false;
                }
            } while (!ok);
            List<double> list = new List<double>() { a1, a2, a3 };
            Rec(list, N);
            Console.WriteLine("Ваша последовательность: ");
            ShowList(list);
            SubsequenceLength(list, out double lastElem, out int count);
            Console.WriteLine("Длина максимальной возрастающей подпоследовательности: {0}", count);
            Console.WriteLine("Последний элемент максимальной возрастающей последовательности: {0}", lastElem);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("(В том случае, если в последовательности несколько подпоследовательностей одинаковой длины, " +
                "последний элемент берется у первой подпоследовательности).");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
