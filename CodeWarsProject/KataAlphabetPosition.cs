namespace CodeWarsProject;

public class KataAlphabetPosition
{
    
    public static string AlphabetPosition(string text)
    {
        return string.Join(" ", text.ToUpper().Select(c => (c - 64)).Where(i => i>0&&i<27).ToList());
    } 
}