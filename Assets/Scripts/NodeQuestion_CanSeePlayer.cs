using UnityEngine;

public class NodeQuestion_CanSeePlayer : NodeQuestion
{
    [SerializeField] Transform owner;
    [SerializeField] Transform target;

    [SerializeField] float minDistToSee = 2f;

    public override bool Predicate()
    {
        Vector3 dir = target.position - owner.position;

        return dir.sqrMagnitude < minDistToSee * minDistToSee;
    }
}
