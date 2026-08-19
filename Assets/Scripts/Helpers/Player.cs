using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    [SerializeField] float speed = 5f;
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * Time.deltaTime * speed;

        if (Mathf.Abs(dir.sqrMagnitude) > 0.1f)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.1f) ;
        }
    }
}
