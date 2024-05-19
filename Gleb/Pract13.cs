using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleb
{
    internal class Pract13: IPract
    {
        int rows = 0;
        int columns = 0;
        int vectorLength = 0;

        List<List<int>> matrix = new List<List<int>>();
        List<int> vector = new List<int>();

        public void InitParams()
        {
            try
            {
                this.InitParamsMatrix();
                this.InitVectorSize();
                this.InitMatrixElements();
                this.InitVectorElements();

            } catch(Exception ex) {
                Console.Clear();
                this.InitParams();
            }
        }

        //Загрузка параметров матрицы
        public void InitParamsMatrix()
        {
            Console.Write("К-сть рядкiв матрицi -> ");
            rows = int.Parse(Console.ReadLine());


            Console.Write("К-сть стовпiв матрицi -> ");
            columns = int.Parse(Console.ReadLine());

            //Валидация данных, если данные неподходят по условию - генерируется исключение
            if (rows <= 0 || columns <= 0)
            {
                throw new Exception();
            }
        }

        //Загрузка размера матрицы
        public void InitVectorSize()
        {
            Console.Write("Ведiть розмiр вектора -> ");
            vectorLength = int.Parse(Console.ReadLine());

            //Проверка, можно ли будет вообще умножать матрицу на вектор
            if (vectorLength != columns)
            {
                throw new Exception();
            }
        }

        //Заполнение значениями матрицу
        public void InitMatrixElements()
        {
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(new List<int>());


                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"a[{i + 1}, {j + 1}] -> ");
                    int value = int.Parse(Console.ReadLine());
                    matrix[i].Add(value);
                }
            }

        }

        //Заполнение значениями вектор
        public void InitVectorElements()
        {
            for (int i = 0; i < vectorLength; i++)
            {
                Console.Write($"V[{i + 1}] -> ");
                int value = int.Parse(Console.ReadLine());
                vector.Add(value);
            }
        }

        public void ExecuteSeq()
        {
            int[] res = new int[matrix.Count];

            for(int i = 0; i < matrix.Count; i++)
            {
                int result = MatrixOperation.MultRowOnVector(this.matrix[i], this.vector);
                res[i] = result;
            }

            Console.WriteLine("Результат: ");

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

    
        public void ExecutePar()
        {

            int[] res = new int[matrix.Count];
 

            Parallel.For(0, matrix.Count, (index) =>
            {
                int sum = MatrixOperation.MultRowOnVector(matrix[index], vector);

                res[index] = sum;

            });

            Console.WriteLine("Результат: ");

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        //Выполнение операции с помощью Task
        public void ExecuteParTask()
        {

            int[] res = new int[matrix.Count];

            List<Task> tasks = new List<Task>();

            for (int index = 0; index < matrix.Count; index++)
            {
                int i = index;

                tasks.Add(Task.Run(() =>
                {
                    int sum = MatrixOperation.MultRowOnVector(matrix[i], vector);

                    res[i] = sum;
                }));
            }

        
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Результат: ");

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

    }
}
