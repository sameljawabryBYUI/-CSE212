using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities: ("Low", 1), ("High", 5), ("Medium", 3). Dequeue them.
    // Expected Result: "High", "Medium", "Low"
    // Defect(s) Found: The Dequeue method does not remove items from the list. It also fails to evaluate the last item in the list because the loop boundary is _queue.Count - 1.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the SAME high priority: ("FirstHigh", 5), ("SecondHigh", 5), ("Low", 1).
    // Expected Result: "FirstHigh", "SecondHigh", "Low"
    // Defect(s) Found: The Dequeue method uses >= instead of > when finding the highest priority. This causes it to pull the newest item instead of the oldest item when there is a priority tie.
    public void TestPriorityQueue_FIFOOnPriorityTie()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 5);
        priorityQueue.Enqueue("SecondHigh", 5);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty PriorityQueue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: No defect found in the exception throwing logic. It correctly throws an InvalidOperationException.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}