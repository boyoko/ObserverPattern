﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppObserver02
{
    // 显示器
    public class Display
    {
        public static void ShowMsg(int param)
        { //静态方法
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", param);
        }
    }
}
