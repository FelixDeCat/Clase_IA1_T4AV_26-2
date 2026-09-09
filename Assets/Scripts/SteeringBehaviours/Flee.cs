using UnityEngine;

public class Flee : BoidBase
{
    private void Update()
    {
        desired = transform.position - Target.Position;

        desired = desired.normalized * moveSpeed;

        steering = desired - velocity;

        steering = Vector3.ClampMagnitude(steering, steeringForce);

        velocity = Vector3.ClampMagnitude( velocity + steering, moveSpeed);

        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity;

    }
}
