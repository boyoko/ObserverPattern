using System;
using System.Text;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            GreetingManager gm = new GreetingManager();

            gm.delegate1 = EnglishGreeting;
            gm.delegate1 += ChineseGreeting;

            //尽管这样做没有任何问题，但我们发现这条语句很奇怪。
            //在调用gm.GreetPeople方法的时候，再次传递了gm的delegate1字段
            //再次修改GreetingManager,在内部调用delegate1，见例子：07
            gm.GreetPeople("Jimmy Zhang", gm.delegate1);


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