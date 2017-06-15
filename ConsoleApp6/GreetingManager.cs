using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    public class GreetingManager
    {
        //定义委托，它定义了可以代表的方法的类型
        public delegate void GreetingDelegate(string name);
        //在GreetingManager类的内部声明delegate1变量
        public GreetingDelegate delegate1;

        public void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

    }
}
