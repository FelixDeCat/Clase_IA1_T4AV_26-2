using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] float detectionRadius = 2f;
    [SerializeField] LayerMask nodeMask;

    float mostClose = float.MaxValue;
    Node best = null;

    private void Start()
    {
        Target.instance.SubscribeToEndClick(OnEndClikc);
    }

    void OnEndClikc()
    {
        Node targetNode = FindMostCloseNode(Target.Position);

        Debug.Log(targetNode);
    }

    public void MoveTo(Vector3 pos)
    {

    }

    Node FindMostCloseNode(Vector3 point)
    {
        Collider[] cols = Physics.OverlapSphere(point, detectionRadius, nodeMask);

        best = null;
        mostClose = detectionRadius + 1;

        for (int i = 0; i < cols.Length; i++)
        {
            Node node = cols[i].GetComponent<Node>();

            if (node != null)
            {
                Vector3 dir = point - node.transform.position;

                if (dir.magnitude < mostClose)
                {
                    mostClose = dir.magnitude;
                    best = node;
                }
            }
        }

        return best;
    }

    void Update()
    {
        
    }
}
