﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPExample
{
    class Program
    {
        static void Main(string[] args)
        {
        //    ObjectClass obj = new ObjectClass();
        //    obj.Test1();
        //    obj.Test2("Test");
        //    obj.Test3(1024);

            ObjectClassAOP objAop = new ObjectClassAOP();
            objAop.Test1();
            objAop.Test2("Test");
            objAop.Test3(1024);

            Console.ReadLine();
        }
    }
}
