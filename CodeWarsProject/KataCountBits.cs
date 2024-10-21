namespace CodeWarsProject;

class KataCountBits
{
    public static int CountBits(int n)
    {
        string binary = Convert.ToString(n, 2);
        Console.WriteLine("Output {0} ",binary);
        return GetOccurrences(binary, "1");
    }
    
    private static int GetOccurrences(string input, string needle)
    {
        int count = 0;
        unchecked
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            for (var i = 0; i < input.Length - needle.Length + 1; i++)
            {
                var c = input[i];
                if (c == needle[0])
                {
                    for (var index = 0; index < needle.Length; index++)
                    {
                        c = input[i + index];
                        var n = needle[index];

                        if (c != n)
                        {
                            break;
                        }
                        else if (index == needle.Length - 1)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }
}