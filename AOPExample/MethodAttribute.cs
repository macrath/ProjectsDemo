﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPExample
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MethodAttribute : Attribute
    {
    }
}
