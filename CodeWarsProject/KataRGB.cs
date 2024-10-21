using System.Text;

namespace CodeWarsProject;

public class KataRGB
{
    
    /*public static string Rgb(int r, int g, int b)
    {
        var red = Convert.ToString(Math.Clamp(r,0,255),16);
        var green = Convert.ToString(Math.Clamp(g,0,255),16);
        var blue = Convert.ToString(Math.Clamp(b,0,255),16);

        return string.Concat(red, green, blue).ToUpper();
    }*/
    public static string Rgb(int r, int g, int b)
    {
        return String.Concat(decToBase(Math.Clamp(r,0,255),16)
            ,decToBase(Math.Clamp(g,0,255),16)
            ,decToBase(Math.Clamp(b,0,255),16));
    }
    public static string decToBase(int num, int baseValue)
    {
        string hexNum = "0123456789ABCDEF";
        

        StringBuilder str = new StringBuilder();
        
        while (num > 0)
        {
            str.Append(hexNum[num % baseValue]);
            num /= baseValue;
        }

        string output = str.ToString();
        
        if (string.IsNullOrEmpty(output))
        {
            return "00";
        }

        if (output.Length == 1)
        {
            return "0"+output;
        }
        return Reverse(str.ToString());
    }
 
    public static string Reverse( string input)
    {
        return string.Create<string>(input.Length, input, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars.Reverse();
        });
    }
    
}
