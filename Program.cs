using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSnippetConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //многопоточность (с кастомными настройками: длительность сущ-ия, приоритет)
            //создаем отдельный поток Thread (using System.Threading)
            //в конструктор должны передать объект ThreadStart
            //(запуск чрз ParameterizedThreadStart, в случае создания потока с параметром
            //+ параметры передаются только типом object)

            Thread thread = new Thread(new ThreadStart(DoWork)); 
            //запускаем наш метод
            thread.Start();

            Thread threadParametr = new Thread(new ParameterizedThreadStart(DoWorkParametr));
            threadParametr.Start(int.MaxValue);

            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;

                if (j % 10000 == 0)
                {
                    Console.WriteLine("Main");
                }

            }

            Console.ReadLine();
        }

        static void DoWork()
        {
            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;

                if(j % 10000 == 0)
                {
                    Console.WriteLine("DoWork");
                }
            }
        }

        static void DoWorkParametr(object max)
        {
            int j = 0;
            for (int i = 0; i < (int)max; i++)
            {
                j++;

                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWorkParametr");
                }
            }
        }
    }
}
