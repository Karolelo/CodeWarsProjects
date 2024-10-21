namespace CodeWarsProject;

public class KataHighestToLowest
{
    public static string HighAndLow(string numbers)
    {
        List<int> numbersList = numbers.Split(" ").Select(int.Parse).ToList();
        
        return string.Concat(numbersList.Max()," ", numbersList.Min());
    }
}