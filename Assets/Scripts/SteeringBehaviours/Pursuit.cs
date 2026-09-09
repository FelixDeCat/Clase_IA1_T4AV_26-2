using UnityEngine;

public class Pursuit : BoidBase
{
    [SerializeField] float predictQuant = 2f;

    private void Update()
    {
        desired = Target.Position + Target.Velocity * predictQuant - transform.position;

        desired = desired.normalized * moveSpeed;

        steering = desired - velocity;

        steering = Vector3.ClampMagnitude(steering, steeringForce);

        velocity = Vector3.ClampMagnitude( velocity + steering, moveSpeed);

        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity;

    }
}
