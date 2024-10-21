namespace CodeWarsProject;

public class KataTwoSum
{
    public static int[] TwoSum(int[] numbers, int target)
    {
        Dictionary<int, int> numberDict = new Dictionary<int, int>();
     
        for (int i = 0; i < numbers.Length; i++)
        {
            int neededNumber = target - numbers[i];
            if (numberDict.ContainsKey(neededNumber))
            {
                return new int[] { numberDict[neededNumber], i };
            }
            
            if (!numberDict.ContainsKey(numbers[i]))
            {
                numberDict[numbers[i]] = i;
            }
        }
        
        return new int[0];
    }
}