using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathEx.Test
{
    public class NodeValue : NodeBase
    {
        public int Value { get; set; }

        public NodeValue(int parm)
        {
            Value = parm;
        }

        public override int Compute()
        {
            return Value;
        }
    }
}
