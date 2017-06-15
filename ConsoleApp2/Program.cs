using System;
using System.Text;

namespace ConsoleApp2
{
    //委托是一个类，它定义了方法的类型，使得可以将方法当作另一个方法的参数来进行传递，
    //这种将方法动态地赋给参数的做法，可以避免在程序中大量使用If-Else(Switch)语句，
    //同时使得程序具有更好的可扩展性。
    //可以将多个方法赋给同一个委托，或者叫将多个方法绑定到同一个委托
    //，当调用这个委托的时候，将依次调用其所绑定的方法
    //案例：04
    //定义委托，它定义了可以代表的方法的类型
    public delegate void GreetingDelegate(string name);
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            GreetPeople("Jimmy Zhang", EnglishGreeting);
            GreetPeople("张子阳", ChineseGreeting);

            Console.ReadKey();
        }


        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }

        //注意此方法，它接受一个GreetingDelegate类型的方法作为参数
        private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

    }
}