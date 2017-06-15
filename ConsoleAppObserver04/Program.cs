using System;
using System.Text;

namespace ConsoleAppObserver04
{


    /*
    为什么要使用事件而不是委托变量？

    在 C#中的委托和事件 中，我提出了两个为什么在类型中使用事件向外部提供方法注册，
    而不是直接使用委托变量的原因。主要是从封装性和易用性上去考虑，
    但是还漏掉了一点，事件应该由事件发布者触发，而不应该由客户端（客户程序）来触发。
    这句话是什么意思呢？请看下面的范例：

    NOTE：注意这里术语的变化，当我们单独谈论事件，我们说发布者(publisher)、
    订阅者(subscriber)、客户端(client)。当我们讨论Observer模式，
    我们说主题(subject)和观察者(observer)。
    客户端通常是包含Main()方法的Program类。 

    */
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Publishser pub = new Publishser();
            Subscriber sub = new Subscriber();

            pub.NumberChanged += new NumberChangedEventHandler(sub.OnNumberChanged);
            pub.DoSomething();          // 应该通过DoSomething()来触发事件

            // 但可以被这样直接调用，对委托变量的不恰当使用
            // 正确的方式为注释掉 Publisher 中的声明委托变量，如下：
            //public NumberChangedEventHandler NumberChanged;         // 声明委托变量
            //打开Publisher 中的声明事件
            //public event NumberChangedEventHandler NumberChanged; // 声明一个事件
            //这样下面的调用方法就不能通过编译
            pub.NumberChanged(100);     


            Console.ReadKey();

        }
    }
}