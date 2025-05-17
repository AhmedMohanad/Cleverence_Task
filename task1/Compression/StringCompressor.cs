using System;
using System.Text;

public static class StringCompressor
{
    // takes a string and compresses repeated characters
    // for example: aaabb becomes a3b2
    public static string Compress(string input)
    {
        if (string.IsNullOrEmpty(input)) return ""; // check if null

        StringBuilder result = new StringBuilder();  // to store the final compressed string
        int count = 1;  

        for (int i = 1; i <= input.Length; i++)
        {
            // if the current char is the same as the previous one ++ the count
            if (i < input.Length && input[i] == input[i - 1])
            {
                count++;
            }
            else
            {
                
                result.Append(input[i - 1]);

                // if it appeared more than onc add the count
                if (count > 1)
                    result.Append(count);

                // reset count 
                count = 1;
            }
        }

        return result.ToString();
    }

    //string back to its original form
    
    public static string Decompress(string input)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];  
            int j = i + 1;
            string num = "";

            // collect all digits after the character (to get the count)
            while (j < input.Length && Char.IsDigit(input[j]))
            {
                num += input[j];
                j++;
            }

            // if there's no number  the character appears once
            int repeat = string.IsNullOrEmpty(num) ? 1 : int.Parse(num);

            // repeat the character 'repeat' times
            result.Append(new string(c, repeat));
            i = j - 1;
        }

        return result.ToString();
    }

   
}
