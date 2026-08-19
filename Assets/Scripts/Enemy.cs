using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Node firstNode;

    
    void Start()
    {
        
    }

    void Update()
    {
        firstNode.Execute();
    }
}
