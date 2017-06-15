using System;
using System.Text;

namespace ConsoleAppObserver01
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Heater ht = new Heater();
            ht.BoilWater();
            /*
             上面的例子显然能完成我们之前描述的工作，但是却并不够好。
             现在假设热水器由三部分组成：热水器、警报器、显示器，
             它们来自于不同厂商并进行了组装。那么，应该是热水器仅仅负责烧水，
             它不能发出警报也不能显示水温；在水烧开时由警报器发出警报、
             显示器显示提示和水温。

                这时候，上面的例子就应该变成这个样子：  Obserer02 
             
             */
            Console.ReadKey();
        }
    }
}