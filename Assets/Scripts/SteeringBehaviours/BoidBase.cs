using UnityEngine;

public abstract class BoidBase : MonoBehaviour
{
    protected Vector3 desired;
    protected Vector3 velocity;
    protected Vector3 steering;

    [Range(0.01f, 0.2f)]
    [SerializeField] protected float steeringForce = 0.1f;

    [SerializeField] protected float moveSpeed = 5f;

    public Vector3 Velocity
    {
        get
        {
            return velocity;
        }
    }
    public Vector3 Steering
    {
        get
        {
            return steering;
        }
    }
    public Vector3 Desired
    {
        get
        {
            return desired;
        }
    }


    private void OnDrawGizmosSelected()
    {
        // desired
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + desired);

        // velocity
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
        
        // steering
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + steering * 50);
    }

}
