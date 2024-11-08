using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    //public T Value;  // The value held by the node
    public GameObject item;
    public int index;
    public Node<T> Next;  // The next node in the circular list

    public Node(T value)
    {
        //Value = value;
        Next = null;
    }
}