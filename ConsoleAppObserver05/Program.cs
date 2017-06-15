using System;
using System.Text;

namespace ConsoleAppObserver05
{

    /*
    为什么委托定义的返回值通常都为void？

    尽管并非必需，但是我们发现很多的委托定义返回值都为void，为什么呢？
    这是因为委托变量可以供多个订阅者注册，如果定义了返回值，
    那么多个订阅者的方法都会向发布者返回数值，
    结果就是后面一个返回的方法值将前面的返回值覆盖掉了，
    因此，实际上只能获得最后一个方法调用的返回值。
    可以运行下面的代码测试一下。除此以外，发布者和订阅者是松耦合的，
    发布者根本不关心谁订阅了它的事件、为什么要订阅，更别说订阅者的返回值了，
    所以返回订阅者的方法返回值大多数情况下根本没有必要。 

    */
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Publishser pub = new Publishser();
            Subscriber1 sub1 = new Subscriber1();
            Subscriber2 sub2 = new Subscriber2();
            Subscriber3 sub3 = new Subscriber3();

            pub.NumberChanged += new GeneralEventHandler(sub1.OnNumberChanged);
            pub.NumberChanged += new GeneralEventHandler(sub2.OnNumberChanged);
            pub.NumberChanged += new GeneralEventHandler(sub3.OnNumberChanged);
            pub.DoSomething();          // 触发事件

            Console.ReadKey();

        }
    }
}