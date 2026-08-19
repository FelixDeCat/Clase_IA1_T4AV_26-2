using UnityEngine;

public class MyCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;
    [SerializeField] float lerpVal = 0.01f;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    Vector3 pos;
    private void LateUpdate()
    {
        pos = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, pos, lerpVal);
    }
}
