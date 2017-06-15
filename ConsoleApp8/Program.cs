using System;
using System.Text;
using static ConsoleApp8.GreetingManager;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            GreetingManager gm = new GreetingManager();
            //gm.MakeGreet = EnglishGreeting;         // 编译错误1
            gm.MakeGreet += ChineseGreeting;

            gm.GreetPeople("Jimmy Zhang");
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