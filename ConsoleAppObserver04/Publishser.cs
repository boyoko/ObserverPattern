using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppObserver04
{

    // 定义委托
    public delegate void NumberChangedEventHandler(int count);


    // 定义事件发布者
    public class Publishser
    {
        private int count;
        public NumberChangedEventHandler NumberChanged;         // 声明委托变量
        //public event NumberChangedEventHandler NumberChanged; // 声明一个事件

        public void DoSomething()
        {
            // 在这里完成一些工作 ...

            if (NumberChanged != null)
            {    // 触发事件
                count++;
                NumberChanged(count);
            }
        }
    }



    /*
     上面代码定义了一个NumberChangedEventHandler委托，
     然后我们创建了事件的发布者Publisher和订阅者Subscriber。
     当使用委托变量时，客户端可以直接通过委托变量触发事件，
     也就是直接调用pub.NumberChanged(100)，这将会影响到所有注册了该委托的订阅者。
     而事件的本意应该为在事件发布者在其本身的某个行为中触发，
     比如说在方法DoSomething()中满足某个条件后触发。通过添加event关键字来发布事件，
     事件发布者的封装性会更好，事件仅仅是供其他类型订阅，
     而客户端不能直接触发事件（语句pub.NumberChanged(100)无法通过编译），
     事件只能在事件发布者Publisher类的内部触发（比如在方法pub.DoSomething()中），
     换言之，就是NumberChanged(100)语句只能在Publisher内部被调用。

    大家可以尝试一下，将委托变量的声明那行代码注释掉，然后取消下面事件声明的注释。
    此时程序是无法编译的，当你使用了event关键字之后，直接在客户端触发事件这种行为，
    也就是直接调用pub.NumberChanged(100)，是被禁止的。
    事件只能通过调用DoSomething()来触发。这样才是事件的本意，事件发布者的封装才会更好。

    就好像如果我们要定义一个数字类型，我们会使用int而不是使用object一样，
    给予对象过多的能力并不见得是一件好事，应该是越合适越好。
    尽管直接使用委托变量通常不会有什么问题，但它给了客户端不应具有的能力，而使用事件，
    可以限制这一能力，更精确地对类型进行封装。

    NOTE：这里还有一个约定俗称的规定，就是订阅事件的方法的命名，通常为“On事件名”，
    比如这里的OnNumberChanged。
     
     */

}
