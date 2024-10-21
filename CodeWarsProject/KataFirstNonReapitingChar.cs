using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;

namespace CodeWarsProject;

public class KataFirstNonReapitingChar
{
    public static string FirstNonRepeatingLetter(string s)
    {
        OrderedDictionary dictionary = new OrderedDictionary();

        foreach (char c in s)
        {
            
            if (dictionary.Contains(c.ToString()))
            {
                var incrementedValue = (Convert.ToInt32(dictionary[c.ToString()])+1);
                dictionary[c.ToString()] = incrementedValue;
            }
            else
            {
                dictionary.Add(c.ToString(), 1);
            }
        };

        foreach (var key in dictionary.Keys)
        {
            if(Convert.ToInt32(dictionary[key])==1)
            {
                string tmp = (string)key;
                if (ValidateChar(tmp[0],dictionary))
                {
                    return tmp;
                }
            }
        }

        return String.Empty;
    }

    public static bool ValidateChar(char c,OrderedDictionary dic)
    {
        if (!char.IsLetter(c))
        {
            return true;
        }

        if (char.IsUpper(c) && !dic.Contains(c.ToString().ToLower()))
        {
            return true;
        }

        if (char.IsLower(c) && !dic.Contains(c.ToString().ToUpper()))
        {
            return true;
        }

        if (!char.IsAscii(c))
        {
            return true;
        }

        return false;
    }
    
    
   
}