using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppObserver02
{
    // 警报器
    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
        }
    }
}
