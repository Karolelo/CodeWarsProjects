namespace CodeWarsProject;

public class KataUniqueInOrder
{
    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
    {
        using (var iterator = iterable.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            
            T previous = iterator.Current;
            yield return previous;
            
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                if (!current.Equals(previous))
                {
                    yield return current;
                    previous = current; 
                }
            }
        }
    }
}