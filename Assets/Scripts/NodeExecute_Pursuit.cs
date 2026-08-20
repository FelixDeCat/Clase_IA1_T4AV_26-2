using UnityEngine;
using IA1.DesitionTreeUnity.Core;

public class NodeExecute_Pursuit : NodeExecute
{
    Vector3 dir = Vector3.zero;

    [SerializeField] Transform owner;


    [SerializeField] float speed = 3f;
    [SerializeField] float lerpQuant = 0.1f;

    public override void Execute()
    {
        dir = Player.Position - owner.position;
        owner.position += dir.normalized * Time.deltaTime * speed;
        owner.forward = Vector3.Lerp(owner.forward, dir, lerpQuant);
    }
}
