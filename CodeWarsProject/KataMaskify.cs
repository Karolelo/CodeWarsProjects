using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWarsProject;

public class KataMaskify
{
    //First version - dobrze działa, ale nie w wersji na codeWars, tam nie ma metod
    /*public static string Maskify(string cc)
    {
        var reversed = ReverseWithStringCreate(cc);
        StringBuilder str = new StringBuilder(reversed.Substring(0,4));
        for (int i = 4; i < reversed.Length; i++)
        {
            if (!Char.IsWhiteSpace(reversed[i]))
            {
               str.Append("#");                 
            }
            else
            {
                str.Append(reversed[i]);
            }
        }

        return ReverseWithStringCreate(str.ToString());
    }*/
    
    /*public static string ReverseWithStringCreate(string input)
    {
        return string.Create(input.Length, input, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars.Reverse();
        });
    }*/
    
    public static string Maskify(string cc)
    {
        switch (cc)
        {
            case string str when str.Length>4:
                var regex = new Regex("[^\\s]");
                var result = new StringBuilder(regex.Replace(cc.Substring(0,cc.Length-4), "#"));
                result.Append(cc.Substring(cc.Length - 4, 4));  
                return result.ToString();
            case string str when str.Length < 4:
                return cc;
        }

        return cc;
    }
    
}