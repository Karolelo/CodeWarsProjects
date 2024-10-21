namespace CodeWarsProject;

public class KataIntervals
{
    
    public static int SumIntervals((int, int)[] intervals)
    {
        intervals=intervals.OrderBy(x=>x.Item1).ToArray();

        var mergedIntervals = new List<(int, int)>();

        foreach (var i in intervals)
        {
            
            if (!mergedIntervals.Any() || mergedIntervals.Last().Item2 < i.Item1)
            {
                mergedIntervals.Add(i);
            }
            else
            {
                if(i.Item2>mergedIntervals.Last().Item2)
                    mergedIntervals[^1] = (mergedIntervals.Last().Item1, i.Item2);
            }
            
            
        }
        
        return mergedIntervals.Sum((tuple => tuple.Item2-tuple.Item1 ));
    }
    
    /*// Determine whether any string in the array is longer than "banana".
    string longestName =
        fruits.Aggregate("banana",
            (longest, next) =>
                next.Length > longest.Length ? next : longest,
            // Return the final result as an upper case string.
            fruit => fruit.ToUpper());*/
    
    public static bool IsOverlap(Tuple<int, int> first, Tuple<int, int> second)
    {
        return first.Item1 < second.Item2 && second.Item1 < first.Item2;
    }
}