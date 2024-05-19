using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleb
{
    internal class Pract15: IPract
    {
        //Размеры первой матрицы
        int rows1 = 0;
        int columns1 = 0;

        //Размеры второй матрицы
        int rows2 = 0;
        int columns2 = 0;

        List<List<int>> matrix1 = new List<List<int>>();
        List<List<int>> matrix2 = new List<List<int>>();
       

        //Словарь, необходим при синхронизации потоков, чтоб грамотно вывести полученный результат (матрицу)
        //Так как последний поток может закончить свое выполнение раньше за первый, словарь гарантирует нам, то что 
        //мы сможем вытянуть нужные строки полученно матрицы (вычисление проходит через испольщзование соответсвующих строк)
        //ключ - индекс строки, значение - строка матрицы результата
        Dictionary<int, List<int>> matrixResult = new Dictionary<int, List<int>>(); 


        //Отображение матрицы
        void DisplayMatrix(List<List<int>> matrix) 
        {
            for (int i = 0; i< matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        public void ExecuteSeq()
        {
           for (int i = 0; i < columns1; i++)
            {
                List<int> resultRow = MatrixOperation.multRowOnMatrxi(matrix1[i], matrix2);

                resultRow.ForEach(value => Console.Write(value + " "));
                Console.WriteLine();
            }
        }

        public void ExecutePar()
        {

            Parallel.For(0, columns1, (int i) =>
            {
                List<int> resultRow = MatrixOperation.multRowOnMatrxi(matrix1[i], matrix2);

         
                this.AddElemntToMatrixResult(i, resultRow);
            });


            for (int i = 0; i < columns1; i++)
            {
                List<int> resultRow = matrixResult[i];
                resultRow?.ForEach(value => Console.Write(value + " "));
                Console.WriteLine();
            }


        }

        //Добавление строки в словарь по ключу (индексу строки)
        void AddElemntToMatrixResult(int key, List<int> row)
        {
            lock(matrixResult)
            {
                matrixResult.Add(key, row);
            }
        }
        
        //Очистка словаря
        public void ClearMatrixResult()
        {
            this.matrixResult.Clear();
        }

        public void ExecuteParTask()
        {

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < columns1; i++)
            {
                int index = i;
                tasks.Add(Task.Run(() =>
                {
                    List<int> resultRow = MatrixOperation.multRowOnMatrxi(matrix1[index], matrix2);
                    this.AddElemntToMatrixResult(index, resultRow);

                }));
            }

            Task.WaitAll(tasks.ToArray());


            for (int i = 0; i < columns1; i++)
            {
                List<int> resultRow = matrixResult[i];
                resultRow.ForEach(value => Console.Write(value + " "));
                Console.WriteLine();
            }
        }


        //Инициализация размеров матриц
        public void InitMatrixSizes ()
        {
            try
            {
                Console.Write("К-сть рядкiв матрицi 1 -> ");
                rows1 = int.Parse(Console.ReadLine());
                Console.Write("К-сть стовпцiв матрицi 1 -> ");
                columns1 = int.Parse(Console.ReadLine());


                Console.Write("К-сть рядкiв матрицi 2 -> ");
                rows2 = int.Parse(Console.ReadLine());
                Console.Write("К-сть стовпцiв матрицi 2 -> ");
                columns2 = int.Parse(Console.ReadLine());

                //Валидация значений на возможность умножений матриц (проверка размеров)
                if (columns1 != rows2 || columns1 <= 0 || rows1 <= 0 || columns2 <= 0 || rows2 <= 0)
                {
                    throw new Exception();
                }



                this.matrix1 = MatrixOperation.GenerateMatrix(rows1, columns1);
                this.matrix2 = MatrixOperation.GenerateMatrix(rows2, columns2);

                this.DisplayMatrix(matrix1);

                Console.WriteLine("\n");
                this.DisplayMatrix(matrix2);
            } catch(Exception e)
            {
                Console.Clear();
                InitMatrixSizes();
            }


        }

    }
}
