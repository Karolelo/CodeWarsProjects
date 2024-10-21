namespace CodeWarsProject;

public class KataDigPow
{
    public static long DigPow(int n, int p) 
    {
        List<int> numbers = new();
        var tmpNumber = n;

        while (tmpNumber > 0)
        {
            numbers.Add(tmpNumber % 10);
            tmpNumber /= 10;
        }

        numbers.Reverse();
        var result = numbers.Select((number, index) => Math.Pow(number, p+index)).Sum();

        if (result % n == 0)
        {
            return (long)result / n;
        }
        
        return -1;
    }
}