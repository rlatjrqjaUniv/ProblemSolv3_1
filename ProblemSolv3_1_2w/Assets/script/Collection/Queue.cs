using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Queue<T>
{
    LinkedList<T> list = new LinkedList<T>();

    public Queue()
    {
        
    }

    public void Enqueue(T Object)
    {
        list.AddBack(Object);
    }

    public T Dequeue()
    {
        if (list.head == null)
        {
            return default;
        }

        Node<T> result = list.head;
        list.head = list.head.nextNode;

        return result.value;
    }

    public T Peek() 
    { 
        if(list.head == null) { return default; }
        return list.head.value; 
    }
    public void Clear() { list.head = null; }
    public Node<T> GetHead() { return list.head; }
}
