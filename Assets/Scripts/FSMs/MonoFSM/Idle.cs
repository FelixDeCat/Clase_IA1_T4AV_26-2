namespace IA1.MonoFSM
{

    using UnityEngine;

    public class Idle : State
    {
        protected override void OnEnter(State from)
        {
            print("Inicio Idle");
        }

        protected override void OnExit()
        {
            print("Finalizo Idle");
        }

        protected override void OnUpdate()
        {
            print("UPDATE Idle");
        }
    }
}