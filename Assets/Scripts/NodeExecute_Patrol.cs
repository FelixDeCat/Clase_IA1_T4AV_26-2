using UnityEngine;
using IA1.DesitionTreeUnity.Core;

public class NodeExecute_Patrol : NodeExecute
{
    [Header("Patrol")]
    [SerializeField] Transform[] wps;
    int index = 0;

    Vector3 dir = Vector3.zero;

    [SerializeField] Transform owner;

    [SerializeField] float speed = 2f;

    [SerializeField] float minDisToChange;

    public override void Execute()
    {
        var trans = wps[index].position;
        
        dir = trans - owner.position;

        if (dir.magnitude < minDisToChange)
        {
            index++;
            if (index >= wps.Length)
            {
                index = 0;
            }
        }

        dir.Normalize();
        owner.position += dir * Time.deltaTime * speed;
    }

}
