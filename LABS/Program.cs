using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace LABS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskL1(args);
            TaskL2();
            TaskL3();
            Task1(args);
        }

        static void TaskL1(string[] args)
        {
            Console.WriteLine("Лабораторная 6.1");
            if (args.Length == 0)
            {
                System.Console.WriteLine("Пожалуйста,укажите имя файла.");
                return;
            }
            string fileName = args[0];
            char[] chars = File.ReadAllText(fileName).ToCharArray();
            CountVowelsAndConsonants(chars);
        }

        //метод для подсчета гласных и согласных букв
        static void CountVowelsAndConsonants(char[] chars)
        {
            int vowelCount = 0;
            int consonantCount = 0;
            string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";

            foreach (char c in chars)
            {
                if (char.IsLetter(c)) // метод показывает,относится ли указанный символ Юникода к категории букв Юникода.
                {
                    if (vowels.Contains(c))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }

            Console.WriteLine($"Количество гласных: {vowelCount}");
            Console.WriteLine($"Количество согласных: {consonantCount}");
        }
        static void TaskL2()
        {
            Console.WriteLine("Лабораторная 6.2");
            int[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] matrix2 = { { 7, 8, 9 }, { 10, 11, 12 }, { 13, 14, 15 } };
            int[,] result = MultiplyMatrix(matrix1, matrix2);
            PrintMatrix(result);
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1; //метод который возвращает индекс последнего элемента в определенной размерности.  
            int columns = matrix.GetUpperBound(1) + 1; //matrix.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        static int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0); //кол-во строк 1 матрицы
            int columns1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int columns2 = matrix2.GetLength(1);

            if (columns1 != rows2)
            {
                throw new Exception("Невозможно умножить матрицы: количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            int[,] result = new int[rows1, columns2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    for (int k = 0; k < columns2; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }

        static void TaskL3()
        {
            Console.WriteLine("Лабораторная 6.3");
            int[,] temperature = new int[12, 30];
            Random rand = new Random();
            //генерация случайных температур
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = rand.Next(-40, 40);
                }
            }
            int[] averageTemperatures = CalculateAverageTemperatures(temperature);

            // Сортировка массива средних температур по возрастанию
            Array.Sort(averageTemperatures);

            Console.WriteLine("Средние температуры по месяцам (отсортированные):");
            for (int i = 0; i < averageTemperatures.Length; i++)
            {
                Console.WriteLine($"Месяц {i + 1}: {averageTemperatures[i]} °C");
            }
        }
   

        // Метод для вычисления средней температуры каждого месяца
        static int [] CalculateAverageTemperatures(int[,] temperature)
        {
            int [] averagesTemperatures = new int [12];

            for (int i = 0; i < 12; i++)
            {
                int sum = 0;
                for (int j = 0; j < 30; j++)
                {
                    sum += temperature[i, j]; 
                }
                averagesTemperatures[i] = sum / 30; 
            }
            return averagesTemperatures; 
        }
         
        static void Task1(string[] args)
        {
            Console.WriteLine("Лабораторная 6.1 c <T>");
            if (args.Length == 0)
            {
                System.Console.WriteLine("Пожалуйста,укажите имя файла.");
                return;
            }
            string fileName = args[0];
            char[] chars = File.ReadAllText(fileName).ToCharArray();
            CountVowelsAndConsonants(chars);
        }

        static void CountVowelAndConsonants(char[] content)
        {
            List<char> vowels = new List<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            int vowelCount = 0;
            int consonantCount = 0;

            foreach (char c in content)
            {
                if (char.IsLetter(c))
                {
                    if (vowels.Contains(char.ToLower(c)))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }

            Console.WriteLine($"Количество гласных: {vowelCount}");
            Console.WriteLine($"Количество согласных: {consonantCount}");
        }
    }
}
