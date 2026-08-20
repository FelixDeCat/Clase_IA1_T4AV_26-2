using UnityEngine;
using IA1.DesitionTreeUnity.Core;

public class NodeQuestion_IsInRange : NodeQuestion
{
    [Header("CanSeePlayer")]
    [SerializeField] Transform owner;
    [SerializeField] float minDistToSee = 2f;

    bool isInRange = false;

    public override bool Predicate()
    {
        Vector3 dir = Player.Position - owner.position;

        isInRange = dir.sqrMagnitude < minDistToSee * minDistToSee; 
        return isInRange;
    }

    private void OnDrawGizmosSelected()
    {
        if (isInRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.up * 0.5f + owner.position, Vector3.up * 0.5f + Player.Position);
        }
    }
}
