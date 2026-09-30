using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class NodeBaker : MonoBehaviour
{
   


    [SerializeField] bool execute;
    [SerializeField] bool update;

    public static NodeBaker Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    [SerializeField] Node[] nodes;
    public Node[] Nodes
    {
        get
        {
            return nodes;
        }
    }

    private void OnEnable()
    {
        EditorApplication.playModeStateChanged += OnStateChanged;
    }
    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnStateChanged;
    }

    void OnStateChanged(PlayModeStateChange st)
    {
        if (st == PlayModeStateChange.EnteredPlayMode)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (execute || update)
        {
            execute = false;
            Debug.Log("Ejecuto en Edit MOde 1 solo Frame");

            nodes = GetComponentsInChildren<Node>();

            foreach (var n in nodes)
            {
                n.BakeN();
            }
        }
    }
}
