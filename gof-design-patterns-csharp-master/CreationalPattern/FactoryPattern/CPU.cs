﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern
{
    public class CPU : IComponent
    {
        public int Price()
        {
            return 25000;
        }
    }
}
