using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    [SerializeField] LayerMask floorsAndObstacles;
    [SerializeField] LayerMask neighborsLayer;
    [SerializeField] LayerMask viewMask;

    [SerializeField] float maxSlope = 0.5f;

    [SerializeField] bool drawConnections;
    [SerializeField] bool drawDetRadius;

    [SerializeField] List<Node> neighbors;
    public List<Node> Neighbors
    {
        get
        {
            return neighbors;
        }
    }

    [SerializeField] float detectionRadius = 2f;

    public void BakeN()
    {
        Adjust();
        Detect();
    }

    Node parent;

    public void Clean()
    {
        parent = null;
        // limpiar costos
        // limpiar costo final
        // limpiar visitados
        // limpiar abiertos
    }

    void Adjust()
    {
        if (Physics.Raycast(transform.position + Vector3.up * 10, Vector3.down, out RaycastHit info, 20, floorsAndObstacles))
        {
            transform.position = info.point + Vector3.up * 0.3f;
        }
    }

    void Detect()
    {
        neighbors = new List<Node>();

        Collider[] colls = Physics.OverlapSphere(transform.position, detectionRadius, neighborsLayer);

        for (int i = 0; i < colls.Length; i++)
        {
            Node node = colls[i].GetComponent<Node>();

            if (node != null && node != this)
            {
                Vector3 dir = node.transform.position - transform.position;

                Ray ray = new Ray();
                ray.origin = transform.position;
                ray.direction = dir;

                if (Physics.Raycast(ray, out RaycastHit info, dir.magnitude, viewMask))
                {
                    Node hitNode = info.collider.GetComponent<Node>();

                    if (hitNode != null && hitNode == node)
                    {
                        float h = node.transform.position.y - transform.position.y;

                        if (Mathf.Abs(h) < maxSlope)
                        {
                            neighbors.Add(node);
                        }
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 0.2f);

        if (drawDetRadius)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }

        if (drawConnections)
        {
            Gizmos.color = Color.white;

            if (neighbors != null)
            {
                for (int i = 0; i < neighbors.Count; i++)
                {
                    Vector3 dir = neighbors[i].transform.position - transform.position;
                    dir /= 3;
                    Gizmos.DrawLine(transform.position, transform.position + dir);
                }
            }
        }
    }

}
