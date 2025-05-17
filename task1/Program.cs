

// here the example test of compression 

string input = "aaabbbbbbbbbbbbbbbbbbcccddde";
string compressed = StringCompressor.Compress(input);
string decompressed = StringCompressor.Decompress(compressed);

Console.WriteLine("Compression excution: \n---------------------------- \n");
Console.WriteLine("Original: " + input);
Console.WriteLine("Compressed: " + compressed);
Console.WriteLine("Decompressed: " + decompressed);
Console.WriteLine(" \n---------------------------- \n");

//////////////////////////////////////////////////////////////////////////////////


// here the example test of Threadt-Safe Counter

// simulate parallel readers
Parallel.For(0, 5, i =>
{
    Console.WriteLine($"[Reader {i}] Count = {ThreadSafeCounter.GetCount()}");
});

// simulate a write
ThreadSafeCounter.AddToCount(10);
Console.WriteLine("Added 10 to count.");

// simulate more readers after writing
Parallel.For(5, 10, i =>
{
    Console.WriteLine($"[Reader {i}] Count = {ThreadSafeCounter.GetCount()}");
});


//////////////////////////////////////////////////////////////////////////


// here example test of - Log Standardizer - task

/*
 
there's some requirements to use below code 

 -  txt file have some data to use called " input_log.txt
 -  txt file to extract and save the output in (it will create automatically if not exist)

*/



string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
// This assumes you run from bin/Debug/netX.X and want to go up 3 levels to project root

string inputPath = Path.Combine(projectFolder, "LogStandardizer", "input_log.txt");
string outputPath = Path.Combine(projectFolder, "LogStandardizer", "output_log.txt");

LogStandardizer.StandardizeLogFile(inputPath, outputPath);





