using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleb
{
    internal class Pract1112 : IPract
    {

        //Размер list, для которого нужно вычислить сумму элементов
        int LIST_SIZE = 10000;

        //Значение суммы, которое используется в паралельном алгоритме
        long sum = 0;

        //Список со значениями 
        List<int> list; 

        //Объект для синхронизации потоков
        object syncObject = new object();

        public Pract1112()
        {
            //Генерация списка с элементами
            this.list = GeneratorList.GenerateList(LIST_SIZE);
            Console.WriteLine("Розмiр масиву: " + LIST_SIZE);
        }



        public void ExecutePar()
        {
            Parallel.For(0, 2, (index) =>
            {
                long sum = this.GetSumElements(this.GetHalfElements(index));
                this.AddNumberToSum(sum);
            });

            Console.WriteLine("Сума: " + this.sum);
        }

        public void ExecuteSeq()
        {
            long firstHalfSum = this.GetSumElements(this.GetHalfElements(0));
            long secondHalfSum = this.GetSumElements(this.GetHalfElements(1));


            Console.WriteLine("Сума: " + (firstHalfSum + secondHalfSum));

        }


        //Потокобезопасный метод, который обезпечивает синхронизацию потоков, с помощью lock
        // Добавляет найденую сумму от определенной половины общего листа и добавляет к уже найденной общей сумме 
        void AddNumberToSum(long number)
        {
            lock(syncObject)
            {
                this.sum += number;
            }
        }

        //Метод который берет определенную половину (первую или вторую), в зависимсоти от индекса: 0 - первая половина, 1 - вторая
        public List<int> GetHalfElements(int halfIndex)
        {
            int halfCount = (list.Count + 1) / 2;

            //skip - пропускает n-е количество элементов
            //Take - берет определенное количество элементов
            return list.Skip(halfIndex * halfCount).Take(halfCount).ToList();
        }

        //возвращает сумму элементов
        long GetSumElements(List<int> list)
        {
            //Sum - стандартный метод LINQ
            return list.Sum(x => x);
        }



    }
}
