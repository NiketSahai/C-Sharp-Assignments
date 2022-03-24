using System;
using System.Linq;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string path = @"D:\Assignments\FileOperations";
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();


        Console.WriteLine("Return the number of text files in the directory (*.txt).");
        Console.WriteLine(".txt - " + GetCountFormat(".txt", files));


        Console.WriteLine("\nReturn the number of files per extension type.");
        GetFormats(files).ToList().ForEach(x => Console.WriteLine(x + " - " + GetCountFormat(x, files)));


        Console.WriteLine("\nReturn the top 5 largest files, along with their file size (use anonymous types).");
        GetCountBytes(files, 5).ToList().ForEach(x => Console.WriteLine(x.FullName + " " + x.Length));


        Console.WriteLine("\nReturn the file with maximum length.");
        GetCountBytes(files, 1).ToList().ForEach(x => Console.WriteLine(x.FullName));


        Console.ReadKey();
    }
    private static string[] GetFormats(FileInfo[] files)
    {
        return files.Where(x => x.FullName.Contains('.'))
                    .Select(x => x.FullName.Remove(0, x.FullName.IndexOf('.')))
                    .Distinct()
                    .ToArray();
    }
    private static int GetCountFormat(string format, FileInfo[] files)
    {
        if (format.Contains(".") == false)
            format = "." + format;
        return files.ToList()
                    .Where(x => x.FullName.Contains(format))
                    .Count();
    }
    private static FileInfo[] GetCountBytes(FileInfo[] files, int countsReceive = 1)
    {
        files = files.OrderBy(x => -x.Length)
                     .ToArray();
        FileInfo[] answer = new FileInfo[countsReceive];
        Array.Copy(files, 0, answer, 0, countsReceive);
        return answer;
    }
}

