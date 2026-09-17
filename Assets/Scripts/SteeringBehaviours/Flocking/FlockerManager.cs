
using System.Collections.Generic;
using UnityEngine;

public class FlockerManager : MonoBehaviour
{
    List<Flocker> list = new List<Flocker>();
    List<Flocker> temp = new List<Flocker>();
    Vector3 dir = Vector3.zero;

    public static FlockerManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    public void SetFlocker(Flocker newFlocker)
    {
        if (!list.Contains(newFlocker))
        {
            list.Add(newFlocker);
        }
    }


    public List<Flocker> GetFlockers(Vector3 pos, float radius, Flocker except = null)
    {
        temp.Clear();

        foreach (Flocker f in list)
        {
            if (f.Equals(except)) continue;

            dir = f.transform.position - pos;

            if (dir.sqrMagnitude < radius * radius)
            {
                temp.Add(f);
            }

        }

        return temp;
    }
}
