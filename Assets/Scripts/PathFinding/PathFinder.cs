using System.Collections.Generic;
using UnityEngine;

public class PathFinder : BoidBase
{
    [SerializeField] float detectionRadius = 2f;
    [SerializeField] LayerMask nodeMask;

    float mostClose = float.MaxValue;
    Node best = null;

    [SerializeField] bool drawOrigin = false;
    [SerializeField] bool drawFinal = false;

    Vector3 origin_to_draw = Vector3.zero;
    Vector3 final_to_draw = Vector3.zero;

    private void Start()
    {
        Target.instance.SubscribeToEndClick(OnEndClick);
    }

    public List<Node> path = new List<Node>();

    int index = -1;
    bool walk = false;
    float closeDist = 0.4f;

    void OnEndClick()
    {

        // Nodo cercano al PathFinder
        Node nodeOrigin = FindMostCloseNode(transform.position);
        if (nodeOrigin != null) origin_to_draw = nodeOrigin.transform.position;
        else origin_to_draw = Vector3.zero;


        // Nodo cercano al Click
        Node nodeFinal = FindMostCloseNode(Target.Position);
        if (nodeFinal != null) final_to_draw = nodeFinal.transform.position;
        else final_to_draw = Vector3.zero;

        if(path == null) path = new List<Node>();
        path.Clear();
        path = BFS(nodeOrigin, nodeFinal);

        if (path != null)
        {
            index = 0;
            walk = true;
        }
    }

    List<Node> BFS(Node initial, Node final)
    {
        foreach (var n in NodeBaker.Instance.Nodes)
        {
            n.Clean();
        }

        Queue<Node> open = new Queue<Node>();
        List<Node> visited = new List<Node>();

        open.Enqueue(initial);
        visited.Add(initial);

        while (open.Count > 0)
        {
            // Forwarding >> El proximo en la Cola de Espera
            Node current = open.Dequeue();

            if (current == final)
            {
                return Reconstruct(initial, final);
            }

            //Explode de vecinos
            foreach (Node n in current.Neighbors)
            {
                if (visited.Contains(n)) continue;

                n.SetParent(current);
                visited.Add(n);
                open.Enqueue(n);
            }
        }

        return null;
    }


    List<Node> Reconstruct(Node initial, Node final)
    {
        List<Node> list = new List<Node>();

        Node current = final;

        while (current != null && current != initial)
        {
            list.Add(current);

            // forwarding >>
            current = current.Parent;
        }

        list.Add(initial);
        list.Reverse();

        return list;
    }

    private void Update()
    {
        if (walk && path != null)
        {
            desired = path[index].transform.position - transform.position;

            if (desired.magnitude < closeDist)
            {
                index = index + 1;
                if (index >= path.Count)
                {
                    index = 0;
                    walk = false;
                }
            }
            else
            {

                desired = desired.normalized * moveSpeed;

                steering = desired - velocity;
                steering = Vector3.ClampMagnitude(steering, steeringForce);

                velocity += steering;
                velocity = Vector3.ClampMagnitude(velocity, moveSpeed);

                transform.position += desired.normalized * Time.deltaTime * moveSpeed;
            }
        }
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
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(origin_to_draw + Vector3.up / 3, 0.2f);
        }

        if (drawFinal && final_to_draw != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(final_to_draw + Vector3.up / 3, 0.2f);
        }
    }
}
