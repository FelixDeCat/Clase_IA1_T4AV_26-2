using UnityEngine;

public class Arriver : BoidBase
{
    [SerializeField] float arrivingDistance = 5f;
    float distance;

    private void Update()
    {
        desired = Target.Position - transform.position;
        
        distance = desired.magnitude;

        if (distance < arrivingDistance)
        {
            desired = desired.normalized * moveSpeed * (distance / arrivingDistance);
        }
        else
        {
            desired = desired.normalized * moveSpeed;
        }

        steering = desired - velocity;

        steering = Vector3.ClampMagnitude(steering, steeringForce);

        velocity = Vector3.ClampMagnitude( velocity + steering, moveSpeed);

        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity;

    }
}
