using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    class Program
    {
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
            } while (!ok);
            List<double> list = new List<double>() { a1, a2, a3 };
            if (N == 3)
                Console.WriteLine("Получившаяся последовательность: ", list);
            if (N == 2)
                Console.WriteLine()
            Rec(list, N);
        }
    }
}
