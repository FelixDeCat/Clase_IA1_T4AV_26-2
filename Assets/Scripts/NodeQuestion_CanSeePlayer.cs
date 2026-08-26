using UnityEngine;
using IA1.DesitionTreeUnity.Core;

public class NodeQuestion_CanSeePlayer : NodeQuestion
{
    [Header("CanSeePlayer")]
    [SerializeField] Transform owner;
    [SerializeField] float minDistToSee = 2f;

    bool canSee = false;

    [SerializeField] FieldOfView fov;

    public override bool Predicate()
    {
        //Vector3 dir = Player.Position - owner.position;

        //canSee = dir.sqrMagnitude < minDistToSee * minDistToSee;

        //return canSee;

        return fov.Query();
    }

    private void OnDrawGizmosSelected()
    {

        if (!Player.Instance) return;

        Gizmos.color = canSee ? Color.cyan : Color.grey;

        Gizmos.DrawLine(transform.position, Player.Position);

        
    }
}
