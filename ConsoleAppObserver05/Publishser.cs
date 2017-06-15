using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppObserver05
{
    // 定义委托
    public delegate string GeneralEventHandler();

    // 定义事件发布者
    public class Publishser
    {
        public event GeneralEventHandler NumberChanged; // 声明一个事件
        public void DoSomething()
        {
            if (NumberChanged != null)
            {    // 触发事件
                string rtn = NumberChanged();
                Console.WriteLine(rtn);     // 打印返回的字符串，输出为Subscriber3
            }
        }
    }
}
