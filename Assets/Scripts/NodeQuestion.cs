using UnityEngine;
using System;

public abstract class NodeQuestion : Node
{

    [SerializeField] Node node_true;
    [SerializeField] Node node_false;

    // Forma por Predicado Obligatorio abstracto
    public abstract bool Predicate(); 


    // Forma por Inyeccion de algoritmo externo
    Func<bool> myPred ;
    public void SetPredicate(Func<bool> _myPred)
    {
        myPred = _myPred;
    }


    public override void Execute()
    {
        // forma 1

        if(Predicate())
        {
            node_true.Execute();
        }
        else
        {
            node_false.Execute();
        }

        /*
        // forma 2
        if(myPred.Invoke())
        {
            node_true.Execute();
        }
        else
        {
            node_false.Execute();
            
        }
        */
    }
}
