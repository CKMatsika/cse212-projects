using System;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Start Problem 1: Insert Unique Values Only
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        // This 'else if' ensures that if value == Data, nothing is inserted.
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Start Problem 2: Contains
        
        // Base case: If the value is found at the current node, return true.
        if (value == Data)
        {
            return true;
        }

        // If the value to find is less than the current node's data,
        // search the left subtree.
        if (value < Data)
        {
            // If the left child is null, the value isn't in the tree.
            // Otherwise, recursively call Contains on the left child.
            return Left is not null && Left.Contains(value);
        }
        // If the value to find is greater than the current node's data,
        // search the right subtree.
        else
        {
            // If the right child is null, the value isn't in the tree.
            // Otherwise, recursively call Contains on the right child.
            return Right is not null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Start Problem 4: Tree Height
        
        // Recursively get the height of the left subtree.
        // If the left child is null, its height is 0.
        int leftHeight = Left?.GetHeight() ?? 0;
        
        // Recursively get the height of the right subtree.
        // If the right child is null, its height is 0.
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // The height of the tree at this node is 1 (for the current node)
        // plus the height of the taller of the two subtrees.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}