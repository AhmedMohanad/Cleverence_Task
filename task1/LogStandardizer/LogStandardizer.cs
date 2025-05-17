using System;
using System.IO;
using System.Text.RegularExpressions;

public static class LogStandardizer
{
    
    public static void StandardizeLogFile(string inputPath, string outputPath)
    {
        // check the input file exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("input file not found.");
            return;
        }

        // read all lines 
        var lines = File.ReadAllLines(inputPath);

        // open the output file for writing (creates it if it doesn't exist)
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            foreach (var line in lines)
            {
                // try to convert each line into the standard format
                string standardizedLine = ConvertToStandardFormat(line);

              
                writer.WriteLine(standardizedLine);
            }
        }

        Console.WriteLine("log standardization complete.");
    }

    // the art is here
    private static string ConvertToStandardFormat(string line)
    {
        // format 1: [INFO] 2025-05-01 10:22:33 - message 
        var match1 = Regex.Match(line, @"\[(\w+)\] (\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) - (.+)");
        if (match1.Success)
        {
            // convert old format to new one ---> timestamp | level | message
            return $"{match1.Groups[2].Value} | {match1.Groups[1].Value} | {match1.Groups[3].Value}";
        }

       
        var match2 = Regex.Match(line, @"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) \| (\w+) \| (.+)");
        if (match2.Success)
        {
            return line.Trim();  // it's already good
        }

        // if we don't recognize the format return it 
        return line;
    }
}
