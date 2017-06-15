using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppObserver05
{
    // 定义事件订阅者
    public class Subscriber1
    {
        public string OnNumberChanged()
        {
            return "Subscriber1";
        }
    }
}
