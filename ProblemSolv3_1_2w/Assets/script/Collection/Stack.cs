using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack
{
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

    public class Stack<T>
    {
        Node<T> first;
        Node<T> last;

        public Stack()
        {
            first = null;
            last = null;
        }

        public void Push(T Object)
        {
            Node<T> temp = new Node<T>(Object);

            if (first == null)
            {
                first = temp;
                last = temp;
            }
            else
            {
                if (last == first)
                {
                    temp.nextNode = first;
                    last = temp;
                }
                else
                {
                    temp.nextNode = last;
                    last = temp;
                }
            }
        }

        public Node<T> Pop()
        {
            if (first == null)
            {
                return null;
            }

            Node<T> result = last;
            last = last.nextNode;

            return result;
        }
    }
}
