namespace IA1.MonoFSM
{
    using UnityEngine;

    public class MonoFSM : MonoBehaviour
    {
        State current;

        public void SetFirst(State _first)
        {
            Swap(_first);
        }

        public void SendInput(string _input)
        {
            if (current == null) return;

            if (current.CanTransitionate(_input))
            {
                State state = current.GetState(_input);

                Swap(state);
            }
        }

        void Swap(State newState)
        {
            if (current != null)
            {
                current.Exit();
            }
            var aux = current;
            current = newState;
            current.Enter(aux);
        }


        private void Update()
        {
            if (current != null)
                current.ManualUpdate();
        }
    }
}
