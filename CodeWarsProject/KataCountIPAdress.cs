using System.Net;

namespace CodeWarsProject;

public class KataCountIPAdress
{
    public static long IpsBetween(string start, string end)
    {
        var startArray = start.Split(".").Select(double.Parse).ToArray();
        var endArray = end.Split(".").Select(double.Parse).ToArray();
        double[] diffrence = new double[endArray.Length];
        
        for (int i = 1; i < 5; i++)
        {
            startArray[i-1] = startArray[i-1]*Math.Pow(256,(double)(4-i));
            endArray[i-1] = endArray[i-1]*Math.Pow(256,(double)(4-i));
        }
        
        var startSum = startArray.Sum();
        var endSum = endArray.Sum();
        
        return (long)Math.Abs(startSum-endSum);
    }
    //Lepsze rozwiązanie 
    /*public static long IpsBetween(string start, string end)
    {
        return (long)(uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(end).Address) - 
               (long)(uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(start).Address);
    }*/
}