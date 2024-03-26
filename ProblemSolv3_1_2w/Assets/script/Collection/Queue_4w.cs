using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Queue2
{
    public class Node_4w<T>
    {
        public T value;
        public Node_4w<T> nextNode;

        public Node_4w(T data)
        {
            value = data;
            nextNode = null;
        }
    }


    public class Queue_4w<T>
    {
        Node_4w<T> head;
        Node_4w<T> foot;

        public Queue_4w()
        {
            head = null;
            foot = null;
        }

        public void Enqueue(T Object)
        {
            Node_4w<T> temp = new Node_4w<T>(Object);

            if (head == null)
            {
                head = temp;
                foot = temp;
                return;
            }
            else
            {
                if (head == foot)
                {
                    head.nextNode = foot;
                    foot.nextNode = temp;
                    foot = foot.nextNode;
                }
                else
                {
                    foot.nextNode = temp;
                    foot = foot.nextNode;
                }

                /*
                while (current.nextNode != null)
                {
                    current = current.nextNode;
                }

                if (current.nextNode == null)
                {
                    current.nextNode = new Node_4w<T>(Object);
                }
                */
            }
        }

        public Node_4w<T> Dequeue()
        {
            if (head == null)
            {
                return null;
            }

            Node_4w<T> result = head;
            head = head.nextNode;

            return result;
        }
    }
}
