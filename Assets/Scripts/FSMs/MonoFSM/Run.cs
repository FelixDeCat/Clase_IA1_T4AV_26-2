namespace IA1.MonoFSM
{
    using UnityEngine;
    public class Run : State
    {
        protected override void OnEnter(State from)
        {
            print("Inicio RUN");
        }

        protected override void OnExit()
        {
            print("Finalizo RUN");
        }

        protected override void OnUpdate()
        {
            print("UPDATE RUN");
        }
    }
}
