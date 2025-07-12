using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: Dequeue should always return the item with the highest priority value.
    // The order should be "High", "Medium", "Low".
    // Defect(s) Found: A common defect is failing to find the highest priority item,
    // perhaps just returning the first or last item in the queue instead. This test
    // ensures the basic priority logic works.
    public void TestPriorityQueue_BasicDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items where two have the same highest priority.
    // Expected Result: Dequeue should return the one that was enqueued first (FIFO).
    // The order should be "First High", then "Second High".
    // Defect(s) Found: The most common bug in a priority queue implementation. The code might
    // find an item with the max priority, but not necessarily the FIRST one that was enqueued.
    // This violates the FIFO tie-breaker rule.
    public void TestPriorityQueue_TieBreaker()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("First High", 10);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("Second High", 10);

        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: The code might throw a different exception (e.g., NullReferenceException)
    // or no exception at all, leading to a crash. This test ensures proper error handling.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            // This is the expected behavior
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception)
        {
            Assert.Fail("An InvalidOperationException was expected.");
        }
    }
}