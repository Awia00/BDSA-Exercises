﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    interface IConnectionBaseStrategy
    {
        AbstractStorageFactory GetStorageFactory();
    }
}
