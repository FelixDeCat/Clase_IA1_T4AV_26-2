namespace IA1.MonoFSM
{
    using UnityEngine;

    public class Attack : State
    {
        protected override void OnEnter(State from)
        {
            print("Inicio Attack");
        }

        protected override void OnExit()
        {
            print("Finalizo Attack");
        }

        protected override void OnUpdate()
        {
            print("UPDATE Attack");
        }
    }
}