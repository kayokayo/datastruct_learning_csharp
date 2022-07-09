using System.Threading;
using System.Collections;
using System;


class Program
{
    static Queue orders = new Queue();
    static object consoleLock = new object();
    static void print(int left, int top, string str)
    {
        // lock(consoleLock)
        // {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(str);
            // Console.Write(str);
        // }
    }
    static void book()
    {
        ConsoleKey key;
        while (true)
        {
            // Thread.Sleep(200);
            Console.Clear();
            Console.SetCursorPosition(0,0);
            print(0, 0, "-----menu-----");
            print(0, 1, "鱼香肉丝");
            print(0, 2, "土豆丝");
            print(0, 3, "红烧肉");
            print(0, 4, "排骨汤");
            // key = ConsoleKey.D5;
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    orders.Enqueue("鱼香肉丝");
                    break;
                case ConsoleKey.D2:
                    orders.Enqueue("土豆丝");
                    break;
                case ConsoleKey.D3:
                    orders.Enqueue("红烧肉");
                    break;
                case ConsoleKey.D4:
                    orders.Enqueue("排骨汤");
                    break;

            }

        }

    }
    static void cook()
    {
        while(true)
        {
            if(orders.Count > 0)
            {
                int sleepTime = new Random().Next(500,3000);
                Thread.Sleep(sleepTime);
                string s = string.Format("已经为您准备好：{0,10}，用时：{1,10}",orders.Peek(),sleepTime/1000f);
                print(0,20,s);
                // Console.WriteLine(s);
                // Console.WriteLine("已经为您准备好：{0,10}，用时：{1,10}",orders.Peek(),sleepTime/1000f);
                orders.Dequeue();
            }
        }


    }

    // static void Main(string[] args)
    // {
    //     // Console.WriteLine("Hello World!");
    //     Thread t = new Thread(book);
    //     t.Start();
    //     cook();
    // }
}
