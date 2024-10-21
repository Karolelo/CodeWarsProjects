namespace CodeWarsProject;

public class KataGetUnique
{
    public static int GetUnique(IEnumerable<int> numbers)
    {
        int first = numbers.First();

        if (numbers.Count(x => x == first) > 1)
        {
            return numbers.First(x=> x != first);
        }

        return first;
    }
}