using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Node<T>
{
    public T value;
    public Node<T> nextNode;

    public Node(T data)
    {
        value = data;
        nextNode = null;
    }
}


public class Queue<T>
{
    Node<T> head;

    public Queue()
    {
        head = null;
    }

    public void Enqueue(T Object)
    {
        Node<T> current = head;

        if (head == null)
        {
            head = new Node<T>(Object);
            return;
        }
        else
        {
            while (current.nextNode != null)
            {
                current = current.nextNode;
            }

            if (current.nextNode == null)
            {
                current.nextNode = new Node<T>(Object);
            }
        }
    }

    public Node<T> Dequeue()
    {
        if(head == null) 
        {
            return null;
        }

        Node<T> result = head;
        head = head.nextNode;

        return result;
    }
}
