using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleb
{
    internal class GeneratorList
    {
        //Заполняет список разніми элементами

        //List - обвертка над обічніми массивами. Под капотам там находится одномерный массив фиксированого размера
        //Если размер все элементы заполнены - внутренний маси автоматически пересоздается с более большой вместимостью
        public static List<int> GenerateList(int size) { 
            var list = new List<int>(); 

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                list.Add(rnd.Next(0, 9));
            }

            return list;
        }
    }
}
