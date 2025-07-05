using System.Collections.Generic;
using System.Linq;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // Plan for MultiplesOf:
        // 1. Create a new array of doubles that will hold the results. Its size must be equal to the 'length' parameter.
        // 2. Use a for-loop that will iterate 'length' times. The loop counter (e.g., 'i') will go from 0 up to (length - 1).
        // 3. Inside the loop, for each position 'i', calculate the correct multiple. Since array indices start at 0, 
        //    the first multiple is (0 + 1) * number, the second is (1 + 1) * number, and so on.
        // 4. Store the calculated multiple in the array at the current index 'i'.
        // 5. After the loop has finished, return the fully populated array.

        // Implementation of the plan:
        double[] multiples = new double[length]; // Step 1

        for (int i = 0; i < length; i++) // Step 2
        {
            // Step 3 & 4
            multiples[i] = number * (i + 1); 
        }

        return multiples; // Step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan for RotateListRight (using the list slicing technique):
        // The goal is to take a "slice" from the end of the list and move it to the beginning.
        // 1. Handle edge cases: If the list is empty or the amount to rotate is zero, there's nothing to do.
        //    Also, rotating by the list's count is the same as not rotating at all. We can use the modulo (%)
        //    operator to handle this and any rotation amounts larger than the list size.
        // 2. Determine the starting index of the "slice" that needs to be moved. This will be 'data.Count - amount'.
        // 3. Create a temporary new list containing the elements from that slice point to the end of the original list.
        //    The GetRange(index, count) method is perfect for this.
        // 4. Remove that same range of elements from the original list. The RemoveRange(index, count) method will do this.
        //    The original list now only contains the first part of the elements.
        // 5. Insert the elements from the temporary list (from step 3) at the very beginning (index 0) of the original list.
        //    The InsertRange(index, collection) method is ideal here. The list is now successfully rotated.

        // Implementation of the plan:
        
        // Step 1: Handle edge cases. If data is null or has 0 or 1 elements, no rotation is possible.
        if (data == null || data.Count <= 1)
        {
            return;
        }

        // Use modulo to handle rotating by amounts larger than the list, or by the list's size itself (which results in 0).
        int rotateAmount = amount % data.Count;
        if (rotateAmount == 0)
        {
            return;
        }

        // Step 2: Determine the starting index of the slice to move.
        int slicePoint = data.Count - rotateAmount;

        // Step 3: Get the right-hand part of the list.
        List<int> rightPart = data.GetRange(slicePoint, rotateAmount);

        // Step 4: Remove the right-hand part from the original list.
        data.RemoveRange(slicePoint, rotateAmount);

        // Step 5: Insert the saved right-hand part at the beginning of the list.
        data.InsertRange(0, rightPart);
    }
}