namespace CodeWarsProject;

public class KataAreTheySame
{
    public static bool comp(int[] a, int[] b)
    {
        if (a == null || b == null) return false;
        int[] squaredA = a.Select(x => x * x).ToArray();
        Array.Sort(squaredA);
        Array.Sort(b);

        return squaredA.SequenceEqual(b);
    }
}