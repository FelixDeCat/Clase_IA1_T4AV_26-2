using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] float detectionRadius = 2f;
    [SerializeField] LayerMask nodeMask;

    float mostClose = float.MaxValue;
    Node best = null;

    [SerializeField] bool drawOrigin = false;

    Vector3 origin_to_draw = Vector3.zero;

    private void Start()
    {
        Target.instance.SubscribeToEndClick(OnEndClick);
    }

    void OnEndClick()
    {
        Node targetNode = FindMostCloseNode(Target.Position);
        if (targetNode != null) origin_to_draw = targetNode.transform.position;
        else origin_to_draw = Vector3.zero;
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

    private void OnDrawGizmos()
    {
        if (drawOrigin && origin_to_draw != Vector3.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(origin_to_draw + Vector3.up / 3, 0.2f);
        }
    }
}
