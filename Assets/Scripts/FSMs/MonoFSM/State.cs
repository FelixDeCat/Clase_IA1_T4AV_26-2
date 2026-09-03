
namespace IA1.MonoFSM
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class State : MonoBehaviour
    {
        // caso Dictionary, ya tengo clave y valor
        // Dictionary<string, State> transitions = new Dictionary<string, State>();

        // coleccion simple
        [SerializeField] List<Transition> transitions_list = new List<Transition>();

        bool isActive;
        public bool IsActive => isActive;
        public void Enter(State from)
        {
            isActive = true;
            if (from == null)
            {
                print("Es el primero");
            }
            OnEnter(from);
        }
        public void Exit()
        {
            isActive = false;
            OnExit();
        }
        public void ManualUpdate()
        {
            if (isActive)
            {
                OnUpdate();
            }
        }


        protected abstract void OnEnter(State from);
        protected abstract void OnExit();
        protected abstract void OnUpdate();

        public bool CanTransitionate(string _input)
        {
            for (int i = 0; i < transitions_list.Count; i++)
            {
                if (transitions_list[i].input == _input)
                {
                    return true;
                }
            }
            return false;
        }

        public State GetState(string _input)
        {
            for (int i = 0; i < transitions_list.Count; i++)
            {
                if (transitions_list[i].input == _input)
                {
                    return transitions_list[i].next;
                }
            }

            return null;
        }
    }

    [System.Serializable]
    public class Transition
    {
        public string input;
        public State next;
    }
}