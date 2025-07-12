public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        // Start at index 1 and loop through the entire queue
        // BUG FIX 1: The loop must go to the end of the list (_queue.Count).
        for (int index = 1; index < _queue.Count; index++)
        {
            // BUG FIX 2: Use > instead of >= to enforce FIFO for tie-breaking.
            // If priorities are equal, we keep the one with the lower index (the one added first).
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Retrieve the item to be dequeued
        var itemToReturn = _queue[highPriorityIndex];
        
        // BUG FIX 3: The item must be removed from the queue.
        _queue.RemoveAt(highPriorityIndex);

        // Return the value of the removed item
        return itemToReturn.Value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}