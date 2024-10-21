using System.Text.RegularExpressions;

namespace CodeWarsProject;

public class KataStripComments
{
    //return Regex.Replace(text, pattern, "", RegexOptions.Multiline);
    public static string StripComments(string text, string[] commentSymbols)
    {
        string pattern = $"[{string.Join("", commentSymbols)}].*$";
        
        var lines = text.Split("\n");
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = Regex.Replace(lines[i], pattern, String.Empty).TrimEnd();
        }
        return string.Join("\n", lines);
    }
}