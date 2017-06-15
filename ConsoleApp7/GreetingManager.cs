using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{
    public class GreetingManager
    {
        //定义委托，它定义了可以代表的方法的类型
        public delegate void GreetingDelegate(string name);
        //在GreetingManager类的内部声明delegate1变量
        public GreetingDelegate delegate1;

        public void GreetPeople(string name)
        {
            //如果有方法注册委托变量
            if (delegate1 != null)
            {     
                delegate1(name);      //通过委托调用方法
            }
        }
    }
}
