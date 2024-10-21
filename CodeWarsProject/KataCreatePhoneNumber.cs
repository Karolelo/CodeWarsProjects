using System.Text.RegularExpressions;

namespace CodeWarsProject;

public class KataCreatePhoneNumber
{
    public static string CreatePhoneNumber(int[] numbers)
    {
        if (numbers == null || numbers.Length != 10)
        {
            throw new ArgumentException("In given array u need to have 10 numbers");
        }
        //całkiem spoko sposób łączenia napisów 
        string concat = numbers.Aggregate("", (current, number) => current + number.ToString());
        
        return Regex.Replace(concat, @"(.{3})(.{3})(.{4})", @"($1) $2-$3");
    }
}