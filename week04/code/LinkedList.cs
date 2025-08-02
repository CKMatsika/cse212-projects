using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the head (beginning) of the list
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode; 
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the tail (end) of the list
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode; 
            newNode.Prev = _tail; 
            _tail = newNode; 
        }
    }

    /// <summary>
    /// Remove the node at the head of the list
    /// </summary>
    public void RemoveHead()
    {
        if (_head is null)
        {
            return;
        }

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            if (_head is not null)
                _head.Prev = null;
        }
    }

    /// <summary>
    /// Remove the node at the tail of the list
    /// </summary>
    public void RemoveTail()
    {
        if (_head is null)
        {
            return;
        }
        
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail!.Prev;
            if (_tail is not null)
                _tail.Next = null;
        }
    }

    /// <summary>
    /// Remove the first node that contains the given value
    /// </summary>
    public void Remove(int value)
    {
        if (_head is null) return;

        Node? current = _head;

        while (current is not null)
        {
            if (current.Data == value)
            {
                if (current == _head)
                {
                    RemoveHead();
                    return; 
                }
                if (current == _tail)
                {
                    RemoveTail();
                    return;
                }
                
                // This handles the middle node case
                if(current.Prev is not null)
                    current.Prev.Next = current.Next;
                if(current.Next is not null)
                    current.Next.Prev = current.Prev;
                
                return; 
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Replace all instances of a value with a new value
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? current = _head;
        
        while (current is not null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            
            current = current.Next;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates backward through the list.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        Node? current = _tail;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates forward through the list.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        Node? current = _head;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
    
    /// <summary>
    /// This is a private implementation for the non-generic IEnumerable interface.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    // The methods below are helpers for the test cases and should not be modified.
    
    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // You can add these helper methods if they are not in another file.
    // The test files seem to call them, so they must exist somewhere.
    // If they are in another file provided by the assignment, you don't need them here.
    public bool HeadAndTailAreNull() {
        return _head is null && _tail is null;
    }

    public bool HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }
    
    // This is a special method needed for one of the tests.
    public void InsertAfter(int valueToFind, int valueToInsert) {
        if (_head is null) return;
        var current = _head;
        while (current is not null) {
            if (current.Data == valueToFind) {
                var newNode = new Node(valueToInsert) { Next = current.Next, Prev = current };
                if (current.Next is not null) {
                    current.Next.Prev = newNode;
                }
                current.Next = newNode;
                if (current == _tail) {
                    _tail = newNode;
                }
                return;
            }
            current = current.Next;
        }
    }
}