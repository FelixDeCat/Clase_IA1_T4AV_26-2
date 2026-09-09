using UnityEngine;

public class NormalMovement : MonoBehaviour
{

    [SerializeField] bool lerp;
    Vector3 velocity = Vector3.zero;
    [SerializeField] float speed = 5f;
    [SerializeField] float lerpSpeed = 5f;

    void Update()
    {
        velocity = Target.Position - transform.position;

        velocity.Normalize();

        if (lerp)
        {

            
            transform.position += velocity * speed * Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward , velocity, lerpSpeed);
        }
        else
        {
            transform.position += velocity * 5 * Time.deltaTime;
        }
    }
}
