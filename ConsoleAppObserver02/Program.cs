using System;
using System.Text;

namespace ConsoleAppObserver02
{
    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Heater heater = new Heater();
            Alarm alarm = new Alarm();

            heater.BoilEvent += alarm.MakeAlert;    //注册方法
            heater.BoilEvent += (new Alarm()).MakeAlert;   //给匿名对象注册方法
            heater.BoilEvent += Display.ShowMsg;       //注册静态方法

            heater.BoilWater();   //烧水，会自动调用注册过对象的方法


            Console.ReadKey();
        }
    }
}