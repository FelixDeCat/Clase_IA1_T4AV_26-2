using System;

public class Attack : State
{
    Action<string> debug;

    public Attack(string _name, Action<string> debug) : base(_name)
    {
        this.debug = debug;
    }

    public override void Begin()
    {
        debug.Invoke("Begin del Attack");
    }

    public override void End()
    {
        debug.Invoke("End del Attack");
    }
}
