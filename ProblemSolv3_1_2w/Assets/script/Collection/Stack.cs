using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack<T>
{
    LinkedList<T> list = new LinkedList<T>();

    public Stack()
    {
        
    }

    public void Push(T Object)
    {
        list.AddFront(Object);
    }

    public T Pop()
    {
        if (list.foot == null)
        {
            return default;
        }

        Node<T> result = list.head;
        list.head = list.head.nextNode;

        return result.value;
    }
}
public class StackWithQueue<T>
{
    Queue<T> bulletQueue1 = new Queue<T>();
    Queue<T> bulletQueue2 = new Queue<T>();

    public StackWithQueue()
    {

    }

    public void Push(T Object)
    {
        bulletQueue1.Enqueue(Object);
    }

    public T Pop()
    {
        T bullet;

        while (true)
        {
            bullet = bulletQueue1.Dequeue();
            if (bulletQueue1.Peek() == null) break;
            else bulletQueue2.Enqueue(bullet);
        }

        while (bulletQueue2.Peek() != null)
        {
            T temp = bulletQueue2.Dequeue();
            bulletQueue1.Enqueue(temp);
        }

        return bullet;
    }
}