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
        // PLAN:
        // 1. Create a new array of doubles with the size of the 'length' parameter.
        // 2. Set up a for-loop that will iterate 'length' times (from index 0 to length - 1).
        // 3. Inside the loop, calculate the current multiple. Since the index starts at 0, 
        //    we multiply the starting 'number' by (index + 1) to get the correct multiple.
        // 4. Assign this calculated value to the current index in the array.
        // 5. After the loop finishes, return the filled array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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
        // PLAN:
        // 1. Find the index where we need to split the list. Since we are moving the last 'amount' 
        //    of items, the starting index for our cut is the total count of the list minus the amount.
        // 2. Use the GetRange method to copy those last items into a new, temporary list.
        // 3. Use the RemoveRange method to delete those items from the end of the original list.
        // 4. Use the InsertRange method to insert the temporary list items at the very beginning 
        //    (index 0) of the original list.

        int splitIndex = data.Count - amount;

        List<int> elementsToMove = data.GetRange(splitIndex, amount);

        data.RemoveRange(splitIndex, amount);

        data.InsertRange(0, elementsToMove);
    }
}