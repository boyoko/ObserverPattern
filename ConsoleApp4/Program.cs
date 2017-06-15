using System;
using System.Text;

namespace ConsoleApp4
{

    //使用委托可以将多个方法绑定到同一个委托变量，当调用此变量时
    //(这里用“调用”这个词，是因为此变量代表一个方法)，
    //可以依次调用所有绑定的方法
    public delegate void GreetingDelegate(string name);

    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            #region 第一种方式
            GreetingDelegate delegate1, delegate2;
            //delegate1 = EnglishGreeting;  等同于 GreetingDelegate delegate1 = new GreetingDelegate(EnglishGreeting);
            delegate1 = EnglishGreeting;
            delegate2 = ChineseGreeting;

            GreetPeople("Jimmy Zhang", delegate1);
            GreetPeople("张子阳", delegate2);
            #endregion

            Console.WriteLine("==============================");

            #region 第二种方式
            GreetingDelegate delegate3;
            delegate3 = EnglishGreeting; // 先给委托类型的变量赋值
            delegate3 += ChineseGreeting;   // 给此委托变量再绑定一个方法

            //如果加上 -= 则取消绑定的方法，只执行ChineseGreeting 方法
            //delegate3 -= EnglishGreeting;

            // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            GreetPeople("Jimmy Zhang", delegate3);
            #endregion

            Console.WriteLine("==============================");


            #region 第三种方式
            GreetingDelegate delegate4;
            delegate4 = EnglishGreeting; // 先给委托类型的变量赋值
            delegate4 += ChineseGreeting;   // 给此委托变量再绑定一个方法

            // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            delegate4("Jimmy Zhang");
            #endregion


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