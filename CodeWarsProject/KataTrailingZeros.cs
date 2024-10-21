namespace CodeWarsProject;

public class KataTrailingZeros
{
    public static int TrailingZeros(int n)
    {
        int upperLimit = (int)Math.Floor(Math.Log(n) / Math.Log(5));
        return (int)Enumerable.Range(1, upperLimit).ToList().Select(x => n / Math.Pow(5, x)).Sum();
    }
}