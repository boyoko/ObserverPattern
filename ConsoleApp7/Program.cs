using System;
using System.Text;

namespace ConsoleApp7
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

            gm.GreetPeople("Jimmy Zhang");      //注意，这次不需要再传递 delegate1变量

            /*
                尽管这样达到了我们要的效果，但是还是存在着问题：

                在这里，delegate1和我们平时用的string类型的变量没有什么分别，而我们知道，
                并不是所有的字段都应该声明成public，合适的做法是应该public的时候public，
                应该private的时候private。

                我们先看看如果把 delegate1 声明为 private会怎样？
                结果就是：这简直就是在搞笑。因为声明委托的目的就是为了把它暴露在类的客户端进行方法的注册，
                你把它声明为private了，客户端对它根本就不可见，那它还有什么用？

                再看看把delegate1 声明为 public 会怎样？结果就是：在客户端可以对它进行随意的赋值等操作，
                严重破坏对象的封装性。

                最后，第一个方法注册用“=”，是赋值语法，因为要进行实例化，第二个方法注册则用的是“+=”。
                但是，不管是赋值还是注册，都是将方法绑定到委托上，除了调用时先后顺序不同，再没有任何的分别，
                这样不是让人觉得很别扭么？

                现在我们想想，如果delegate1不是一个委托类型，而是一个string类型，你会怎么做？
                答案是使用属性对字段进行封装。

                于是，Event出场了，它封装了委托类型的变量，使得：在类的内部，
                不管你声明它是public还是protected，它总是private的。在类的外部，
                注册“+=”和注销“-=”的访问限定符与你在声明事件时使用的访问符相同。

                见例子：08 
             */



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