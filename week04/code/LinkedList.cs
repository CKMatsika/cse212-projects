using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class LinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value;
        public Node Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head;

    public LinkedList()
    {
        head = null;
    }

    // Insert at the head
    public void InsertHead(T value)
    {
        Node newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
    }

    //  Insert at the tail
    public void InsertTail(T value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    //  Remove head
    public void RemoveHead()
    {
        if (head != null)
        {
            head = head.Next;
        }
    }

    //  Remove tail
    public void RemoveTail()
    {
        if (head == null) return;

        if (head.Next == null)
        {
            head = null;
            return;
        }

        Node current = head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        current.Next = null;
    }

    //  Remove a specific value
    public void Remove(T value)
    {
        if (head == null) return;

        if (EqualityComparer<T>.Default.Equals(head.Value, value))
        {
            RemoveHead();
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Value, value))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    // Replace all occurrences of oldValue with newValue
    public void Replace(T oldValue, T newValue)
    {
        Node current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, oldValue))
            {
                current.Value = newValue;
            }
            current = current.Next;
        }
    }

    // Forward iteration
    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    //  Reverse iteration
    public IEnumerable<T> Reverse()
    {
        Stack<T> stack = new Stack<T>();
        Node current = head;
        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Next;
        }

        while (stack.Count > 0)
        {
            yield return stack.Pop();
        }
    }
}
