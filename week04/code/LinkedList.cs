using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    public void InsertHead(int value)
    {
        // TODO: Insert new node at head
        Node newNode = new(value);
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    public void InsertTail(int value)
    {
        // TODO: Insert new node at tail
        Node newNode = new(value);
        if (_tail == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    public void RemoveHead()
    {
        // TODO: Remove node at head
        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else if (_head != null)
        {
            _head = _head.Next;
            _head!.Prev = null;
        }
    }

    public void RemoveTail()
    {
        // TODO: Remove node at tail
        if (_tail == _head)
        {
            _head = _tail = null;
        }
        else if (_tail != null)
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
    }

    public void InsertAfter(int value, int newValue)
    {
        // TODO: Insert newValue after node with value
        Node? curr = _head;
        while (curr != null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    public void Remove(int value)
    {
        // TODO: Remove node with matching value
        Node? curr = _head;
        while (curr != null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        // TODO: Replace node value
        Node? curr = _head;
        while (curr != null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable Reverse()
    {
        Node? current = _tail;
        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    public Boolean HeadAndTailAreNull()
    {
        return _head == null && _tail == null;
    }

    public Boolean HeadAndTailAreNotNull()
    {
        return _head != null && _tail != null;
    }
}
