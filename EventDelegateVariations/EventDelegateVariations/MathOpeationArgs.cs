﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{
    public class MathOperationArgs : EventArgs
    {
        public double x { get; set; }
        public double y { get; set; }
    }

}
