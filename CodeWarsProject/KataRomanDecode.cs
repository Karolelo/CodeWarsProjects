using Microsoft.VisualBasic;

namespace CodeWarsProject;
using System.Collections.Generic;
public class KataRomanDecode
{
    private static Dictionary<string,int> romanNumber = new Dictionary<string, int>()
    {
        { "I", 1 },
        {"IV",4},
        {"V",5},
        {"IX",9},
        {"X",10},
        {"XL",40},
        {"L",50},
        {"XC",90},
        {"C",100},
        {"CD",400},
        {"D",500},
        {"CM",900},
        {"M",1000}
    };
    
    public static int Solution(string roman)
    {
        var digits = roman.ToCharArray();
        
        string previous = digits[0].ToString();
        string current;
        int result = 0;

        for (int i = 0; i < digits.Length; i++)
        {
            current = digits[i].ToString();
            if (romanNumber[previous] < romanNumber[current])
            {
                result -= romanNumber[previous];
                result+=romanNumber[string.Concat(previous,current)];
            }
            else
            {
                result+=romanNumber[current];
            }
            previous = current;
        }

        return result;
    }
    
    //Myslałem o konwersji z liczbowych na rzymskie, troche inaczej sie to robi
    /*private static int GetLenghtOfNumber(int number)
    {
        int lenght = 0;
        while (number > 0)
        {
            number /= 10;
            lenght++;
        }
        return lenght;
    }

    private static int GetFirstDivisor(int lenghtOfNumber)
    {
        return (int)Math.Pow(10, lenghtOfNumber);
    }
    private static string GetClosestNumber(int number)
    {
        return romanNumber.OrderBy(kvp => Math.Abs(kvp.Value - number)).First().Key;
    }*/
}