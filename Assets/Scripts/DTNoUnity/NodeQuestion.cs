
using System;

namespace IA1.DesitionTreeCSharpNative
{
    public class NodeQuestion : Node
    {
        Func<bool> predicate ;
        Node ntrue;
        Node nfalse;

        public NodeQuestion(Func<bool> _predicate, Node _node_true, Node _node_false)
        {
            predicate = _predicate;
            ntrue = _node_true;
            nfalse = _node_false;
        }

        public override void Execute()
        {
            if (predicate.Invoke())
            {
                ntrue.Execute();
            }
            else
            {
                nfalse.Execute();
            }
        }
    }
}
