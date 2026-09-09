using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    Transform camtransf;
    [SerializeField] Vector3 camOffset;
    private void Start()
    {
        camtransf = Camera.main.transform;
    }
    public static Transform Transform
    {
        get
        {
            return Instance.transform;
        }
    }
    public static Vector3 Position
    {
        get
        {
            return Instance.transform.position;
        }
    }


    Vector3 dir = Vector3.zero;
    [SerializeField] float speed = 5f;
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * Time.deltaTime * speed;

        if (Mathf.Abs(dir.sqrMagnitude) > 0.01f)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.1f);
        }
    }

    
    private void LateUpdate()
    {
        camtransf.position = this.transform.position + camOffset;
    }
}
