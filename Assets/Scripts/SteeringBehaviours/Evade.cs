using UnityEngine;

public class Evade : BoidBase
{
    [SerializeField] float predictQuant = 2f;

    private void Update()
    {
        desired = transform.position - Target.Position + Target.Velocity * predictQuant;

        desired = desired.normalized * moveSpeed;

        steering = desired - velocity;

        steering = Vector3.ClampMagnitude(steering, steeringForce);

        velocity = Vector3.ClampMagnitude( velocity + steering, moveSpeed);

        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity;

    }
}
