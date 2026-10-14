using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PriorityQueue<T>
{
    List<PriorityPair<T>> list;

    public int Count { get { return list.Count; } }

    public PriorityQueue()
    {
        list = new List<PriorityPair<T>>();
    }

    public void Enqueue(T _data, float _priority)
    {
        // solo para buscar los que ya tenia y actualizar
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].data.Equals(_data))
            {
                list[i].UpdatePriority(_priority);
                OrderList();
                return;
            }
        }

        PriorityPair<T> pair = new PriorityPair<T>(_data, _priority);
        list.Add(pair);
        OrderList();
    }

    void OrderList() ///es un poco costoso, se puede remplazar por Min Heap o Max Heap, o algun tipo de Lista enlazada falopa
    {
        list = list
            .OrderBy(a => a.priority)
            .ToList();
    }

    public T Dequeue()
    {
        T element = list[0].data;
        list.RemoveAt(0);

        if (element.Equals(default(T))) Debug.LogWarning("No hay mas elementos");
        return element;
    }
        
}

public struct PriorityPair<T>
{
    public T data;
    public float priority;

    public PriorityPair(T _data, float _prior)
    {
        data = _data; 
        priority = _prior;
    }

    public void UpdatePriority(float _prior)
    {
        priority = _prior;
    }


}
