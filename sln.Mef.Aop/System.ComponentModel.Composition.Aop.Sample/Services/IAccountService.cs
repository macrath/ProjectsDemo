﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition.Aop.Sample.Services
{
    public interface IAccountService
    {
        bool CreateUser(string username, string password);

        bool ExistsUser(string username);

    }
}
