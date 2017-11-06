using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathEx.Test
{
    class NodeOperator : NodeBase
    {
        private INode LeftNode;
        private INode RightNode;
        private Operator Op;

        public NodeOperator(Operator op, NodeBase leftNode, NodeBase rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
            Op = op;
        }

        public override int Compute()
        {
            switch (Op)
            {
                case Operator.ADD:
                    return LeftNode.Compute() + RightNode.Compute();
                case Operator.SUB:
                    return LeftNode.Compute() - RightNode.Compute();
                case Operator.MUL:
                    return LeftNode.Compute() * RightNode.Compute();
                case Operator.DIV:
                    return LeftNode.Compute() / RightNode.Compute();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
