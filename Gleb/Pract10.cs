using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleb
{
    internal class Pract10
    {
        //поле отвечает за вывод сообщения: Привет или пока 
        bool isHiDisplaying = true;

        //Объект для синхронизации потоков
        object syncObject = new object();

        //Последовательное выполнение алгоритма
        public void ExecuteSeq()
        {
            for (int i = 0; i < 20; i++)
            {
                this.DisplayCurrentMessage();
                this.ChangeDisplayedMessage();
            }

        }

        //Паралельное выполнение алгоритма
        public void ExecutePar()
        {
            Parallel.For(0, 20, (index) =>
            {
                lock (this.syncObject)
                {
                    this.DisplayCurrentMessage();
                    this.ChangeDisplayedMessage();
                }
            });

        }

        //меняет значение переменной, которая отвечает за показ текущего сообщения на противоположное 
        void ChangeDisplayedMessage() => this.isHiDisplaying = !this.isHiDisplaying;
            
        
        void DisplayHi() => Console.WriteLine("Привiт");
        void DisplayBye() => Console.WriteLine("\t\tБувай");
        void DisplayCurrentMessage()
        {
            if (this.isHiDisplaying)
            {
                this.DisplayHi();
            }
            else
            {
                this.DisplayBye();
            }
        }

    }
}
