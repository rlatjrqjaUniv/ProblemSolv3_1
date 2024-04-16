using System.Collections;
using System.Collections.Generic;
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

public class LinkedList<T>
{
    public Node<T> head;
    public Node<T> foot;

    public LinkedList()
    {
        head = null; 
        foot = null;
    }

    public void AddBack(T data)
    {
        Node<T> tempNode = new Node<T>(data);

        if(head == null) 
        {
            head = tempNode;
            foot = tempNode;
        }
        else
        {
            if(head == foot)
            {
                foot = tempNode;
                head.nextNode = foot;
            }
            else 
            {
                foot.nextNode = tempNode;
                foot = foot.nextNode;
            }
        }
    }

    public void AddFront(T data) 
    {
        Node<T> tempNode = new Node<T>(data);

        if(head == null)
        {
            head = tempNode;
            foot = tempNode;
        }
        else
        {
            tempNode.nextNode = head;
            head = tempNode;
        }
    }
}
