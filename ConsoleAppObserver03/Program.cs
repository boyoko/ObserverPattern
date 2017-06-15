using System;
using System.Text;

namespace ConsoleAppObserver03
{
    //http://www.cnblogs.com/JimmyZhang/archive/2007/09/23/903360.html

    /*
    .Net Framework中的委托与事件

    尽管上面的范例很好地完成了我们想要完成的工作，但是我们不仅疑惑：
    为什么.Net Framework 中的事件模型和上面的不同？为什么有很多的EventArgs参数？

    在回答上面的问题之前，我们先搞懂 .Net Framework的编码规范：

    委托类型的名称都应该以EventHandler结束。

    委托的原型定义：有一个void返回值，并接受两个输入参数：一个Object 类型，
    一个 EventArgs类型(或继承自EventArgs)。
    事件的命名为 委托去掉 EventHandler之后剩余的部分。
    继承自EventArgs的类型应该以EventArgs结尾。

    再做一下说明：

    委托声明原型中的Object类型的参数代表了Subject，也就是监视对象，
    在本例中是 Heater(热水器)。回调函数(比如Alarm的MakeAlert)
    可以通过它访问触发事件的对象(Heater)。

    EventArgs 对象包含了Observer所感兴趣的数据，在本例中是temperature。
    上面这些其实不仅仅是为了编码规范而已，这样也使得程序有更大的灵活性。
    比如说，如果我们不光想获得热水器的温度，
    还想在Observer端(警报器或者显示器)方法中获得它的生产日期、型号、价格，
    那么委托和方法的声明都会变得很麻烦，而如果我们将热水器的引用传给警报器的方法，
    就可以在方法中直接访问热水器了。

    现在我们改写之前的范例，让它符合 .Net Framework 的规范： 
    */

    class Program
    {
        static void Main(string[] args)
        {
            //解决中文乱码
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Heater heater = new Heater();
            Alarm alarm = new Alarm();

            //heater.Boiled += alarm.MakeAlert;   //注册方法
            //heater.Boiled += (new Alarm()).MakeAlert;      //给匿名对象注册方法
            heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);    //也可以这么注册
            //heater.Boiled += Display.ShowMsg;       //注册静态方法

            heater.BoilWater();   //烧水，会自动调用注册过对象的方法


            Console.ReadKey();
        }
    }
}