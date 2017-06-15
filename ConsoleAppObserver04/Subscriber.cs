using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppObserver04
{
    // 定义事件订阅者
    public class Subscriber
    {
        public void OnNumberChanged(int count)
        {
            Console.WriteLine("Subscriber notified: count = {0}", count);
        }
    }
}
