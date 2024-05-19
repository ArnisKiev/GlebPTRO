using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleb
{
    //Класс для работы с матрицами
    internal class MatrixOperation
    {

        //Умножает строку матрицы на вектор (стандартный математический алгоритм)
        public static int MultRowOnVector(List<int> row, List<int> vector)
        {
            int sum = 0;
            for (int i = 0; i < row.Count; i++)
            {
                sum += vector[i] * row[i];
            }

            return sum;
        }

        // List<List<int>> - матрица с использованием List, вместо двумерніх массивов
        // Генерирует матрицу и заполняет ее элементы случайными значениями
        public static List<List<int>> GenerateMatrix(int rows, int columns)
        {
            List<List<int>> matrix = new List<List<int>>();

            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                matrix.Add(new List<int>());

                for (int j = 0; j < columns; j++)
                {
                    matrix[i].Add(rnd.Next(0 , 9));
                }
            }


            return matrix;

        }

        //Стандартный код (алгоритм) умножения матриц
        public static List<int> multRowOnMatrxi(List<int> row, List<List<int>> matrix)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < matrix.Count; i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.Count; j++)
                {
                    sum += matrix[j][i] * row[j];
                }

                result.Add(sum);
            }

            return result;
        }

    }
}
