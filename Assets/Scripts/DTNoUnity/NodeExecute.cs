using System;

namespace IA1.DesitionTreeCSharpNative
{
    public class NodeExecute : Node
    {
        Action toExecute;

        public NodeExecute(Action _toExecute) 
        {
            toExecute = _toExecute;
        }

        public override void Execute()
        {
            toExecute.Invoke();
        }
    }
}