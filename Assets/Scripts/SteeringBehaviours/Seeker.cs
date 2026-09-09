using UnityEngine;

public class Seeker : BoidBase
{
    private void Update()
    {
        desired = Target.Position - transform.position;

        desired = desired.normalized * moveSpeed;

        steering = desired - velocity;

        steering = Vector3.ClampMagnitude(steering, steeringForce);

        velocity = Vector3.ClampMagnitude( velocity + steering, moveSpeed);

        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity;

    }
}
