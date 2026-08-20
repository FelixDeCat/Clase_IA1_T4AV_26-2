
using UnityEngine;
using IA1.DesitionTreeUnity.Core;

public class NodeExecute_Attack : NodeExecute
{
    float timer = 0;
    [SerializeField] float time_to_attack = 2f;

    public override void Execute()
    {
        if (timer < time_to_attack)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        else
        {
            timer = 0;
            print("<color=red>Ataco!!!</color>");
        }
    }
}
