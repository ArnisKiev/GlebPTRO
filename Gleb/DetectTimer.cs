using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleb
{

    //класс для измерения времени выполнения кода (стоит обращать внимание на милисекунды fff) 
    internal class DetectTimer
    {
        public void Start() => Console.WriteLine("Початковий час: " + DateTime.Now.ToString("HH:mm:ss.fff"));

        public void Stop() => Console.WriteLine("Кiнцевий час: " + DateTime.Now.ToString("HH:mm:ss.fff"));
    }
}
