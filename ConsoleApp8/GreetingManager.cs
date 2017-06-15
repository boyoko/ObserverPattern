using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{

    
    public class GreetingManager
    {
        //定义委托，它定义了可以代表的方法的类型
        public delegate void GreetingDelegate(string name);
        //这一次我们在这里声明一个事件
        public event GreetingDelegate MakeGreet;
        /*
        很容易注意到：MakeGreet 事件的声明与之前委托变量delegate1的声明唯一的区别
        是多了一个event关键字。看到这里，在结合上面的讲解，
        你应该明白到：事件其实没什么不好理解的，
        声明一个事件不过类似于声明一个进行了封装的委托类型的变量而已。 
    */
        public void GreetPeople(string name)
        {
            MakeGreet(name);
        }
    }
}
