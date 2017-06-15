using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppObserver02
{
    /*
     这里就出现了一个问题：如何在水烧开的时候通知报警器和显示器？
     在继续进行之前，我们先了解一下Observer设计模式，
     Observer设计模式中主要包括如下两类对象：

    Subject：监视对象，它往往包含着其他对象所感兴趣的内容。在本范例中，
    热水器就是一个监视对象，它包含的其他对象所感兴趣的内容，就是temprature字段，
    当这个字段的值快到100时，会不断把数据发给监视它的对象。

    Observer：监视者，它监视Subject，当Subject中的某件事发生的时候，
    会告知Observer，而Observer则会采取相应的行动。在本范例中，
    Observer有警报器和显示器，它们采取的行动分别是发出警报和显示水温。
    在本例中，事情发生的顺序应该是这样的：

    警报器和显示器告诉热水器，它对它的温度比较感兴趣(注册)。
    热水器知道后保留对警报器和显示器的引用。
    热水器进行烧水这一动作，当水温超过95度时，通过对警报器和显示器的引用，
    自动调用警报器的MakeAlert()方法、显示器的ShowMsg()方法。
    类似这样的例子是很多的，GOF对它进行了抽象，称为Observer设计模式：
    Observer设计模式是为了定义对象间的一对多的依赖关系，
    以便于当一个对象的状态改变时，其他依赖于它的对象会被自动告知并更新。
    Observer模式是一种松耦合的设计模式。
         
         
     */





    // 热水器
    public class Heater
    {
        private int temperature;

        public delegate void BoilHandler(int param);   //声明委托
        public event BoilHandler BoilEvent;        //声明事件

        // 烧水
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;

                if (temperature > 95)
                {
                    //如果有对象注册
                    if (BoilEvent != null)
                    { 
                        BoilEvent(temperature);  //调用所有注册对象的方法
                    }
                }
            }
        }
    }
}
