using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base Case: If n is less than or equal to 0, there's nothing to sum.
        if (n <= 0)
        {
            return 0;
        }
        
        // Recursive Step: The sum for 'n' is (n*n) plus the sum of all squares up to (n-1).
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string currentWord = "")
    {
        // Base Case: If the permutation we are building has reached the desired size,
        // add it to the results list and stop this recursive path.
        if (currentWord.Length == size)
        {
            results.Add(currentWord);
            return;
        }

        // Recursive Step: Iterate through each available letter.
        for (int i = 0; i < letters.Length; i++)
        {
            // Create a new string of remaining letters by removing the one we are about to use.
            string remainingLetters = letters.Remove(i, 1);
            // Make a recursive call with the smaller set of letters and the updated word.
            PermutationsChoose(results, remainingLetters, size, currentWord + letters[i]);
        }
    }


    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize the memoization dictionary on the first call.
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Base Cases
        // If s is negative, it's an impossible scenario that contributes 0 ways.
        if (s < 0)
        {
            return 0;
        }
        // If s is 0, there is exactly one way to be at the top: by having already arrived.
        if (s == 0)
        {
            return 1;
        }

        // Check the cache (Memoization). If we've solved for 's' before, return the stored answer.
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }
        
        // Recursive Step: The number of ways to climb 's' stairs is the sum of the ways
        // to get to the preceding steps from which we can make a valid move.
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        
        // Store the newly calculated result in the cache before returning.
        remember[s] = ways;
        
        return ways;
    }


    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base Case: If there are no more wildcards, the pattern is complete.
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive Step: Replace the wildcard with '0' and recurse.
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        
        // Replace the wildcard with '1' and recurse.
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Base Case 1: Check if the move is valid using the CORRECT argument order.
        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }

        // Add the current valid move to our path.
        currPath.Add((x, y));

        // Base Case 2: We have found the end of the maze.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            // Backtrack to allow finding other paths.
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Recursive Step: Explore all four directions.
        SolveMaze(results, maze, x, y + 1, currPath); // Down
        SolveMaze(results, maze, x + 1, y, currPath); // Right
        SolveMaze(results, maze, x, y - 1, currPath); // Up
        SolveMaze(results, maze, x - 1, y, currPath); // Left

        // Backtracking Step: Remove the current spot from the path so that previous
        // recursive calls can explore other branches.
        currPath.RemoveAt(currPath.Count - 1);
    }
}