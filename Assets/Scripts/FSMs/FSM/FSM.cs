using System.Collections.Generic;

public class FSM 
{
    State current;
    public FSM(State first)
    {
        Swap(first);
    }

    public void SendInput(string _input)
    {
        if (current.IHaveThisInput(_input))
        {
            var state = current.GetState(_input);

            Swap(state);
        }
    }

    void Swap(State state)
    {
        if(current != null) current.End(); //Solamente para la primera vez
        current = state;
        current.Begin();
    }


    public void UpdateFSM()
    {
        current.Update();
    }
}

public class State
{
    Dictionary<string, State> transitions;
    string name;

    public State(string _name)
    {
        name = _name;
        transitions = new Dictionary<string, State>();
    }

    public virtual void Begin()
    {

    }
    public virtual void End()
    {

    }
    public virtual void Update()
    {

    }



    public void AddTransition(string inputKey, State state)
    {
        if (transitions.ContainsKey(inputKey))
        {
            throw new System.Exception($"Esta Key ya existe, que quisiste hacer KEY:{inputKey}");
        }
        else
        {
            transitions.Add(inputKey, state);
        }
    }
    public bool IHaveThisInput(string inputKey)
    {
        return transitions.ContainsKey(inputKey);
    }
    public State GetState(string inputKey)
    {
        return transitions[inputKey];
    }

}

//public class Transition
//{
//    public Transition(string _input, State _next)
//    {
//        input = _input;
//        next = _next;
//    }
//    string input;
//    State next;

//    public string Input
//    {
//        get
//        {
//            return input;
//        }
//    }
//    public State State
//    {
//        get
//        {
//            return next;
//        }
//    }
//}