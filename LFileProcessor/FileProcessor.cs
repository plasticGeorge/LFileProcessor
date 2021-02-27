using System;
using System.IO;

namespace LFileProcessor
{
    public class FileProcessor
    {
        public void ProcessFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                Type fileType = Type.GetType($"LFileProcessor.{Path.GetExtension(fileName).Trim('.').ToUpper()}FileProcessor");
                if (fileType != null)
                {
                    IFileProcessor fileProcessor = (IFileProcessor)Activator.CreateInstance(fileType);
                    fileProcessor.Process(fileName);
                }
                else
                    throw new ArgumentException("The file format is incorrect...");
            }
            else
                throw new ArgumentException("The file doesn\'t exist...");
        }
    }

    public interface IFileProcessor
    {
        void Process(string fileName);
    }

    class HTMLFileProcessor : IFileProcessor
    {
        public void Process(string fileName)
        {
            Console.WriteLine("Processing an .html file");
        }
    }
    class TXTFileProcessor : IFileProcessor
    {
        public void Process(string fileName)
        {
            Console.WriteLine("Processing an .txt file");
        }
    }
    class JSONFileProcessor : IFileProcessor
    {
        public void Process(string fileName)
        {
            Console.WriteLine("Processing an .json file");
        }
    }
}
