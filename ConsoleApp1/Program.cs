using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //测试输出中文
            //Console.WriteLine("你好");

            GreetPeople("老赵",Language.Chinese);
            GreetPeople("zz",Language.English);

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

        public enum Language
        {
            English, Chinese
        }

        public static void GreetPeople(string name, Language lang)
        {
            //做某些额外的事情，比如初始化之类，此处略
            switch(lang){
                case Language.English:
                EnglishGreeting(name);
                break;
            case Language.Chinese:
                ChineseGreeting(name);
                break;
            }
        }
    }
}