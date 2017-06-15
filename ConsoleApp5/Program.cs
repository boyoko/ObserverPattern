using System;
using System.Text;

namespace ConsoleApp5
{
    class Program
    {
        


        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            #region 第一种调用
            GreetingManager gm = new GreetingManager();

            gm.GreetPeople("Jimmy Zhang", EnglishGreeting);
            gm.GreetPeople("张子阳", ChineseGreeting);
            #endregion

            Console.WriteLine("===========================");


            #region 第二种调用,既然可以声明委托类型的变量(在下例中是delegate1)，我们何不将这个变量封装到 GreetManager类中？在这个类的客户端中使用不是更方便么？于是，我们改写GreetManager类，像这样：06
            GreetingManager gm2 = new GreetingManager();
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting;
            delegate1 += ChineseGreeting;

            gm.GreetPeople("Jimmy Zhang", delegate1);
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

    }
}