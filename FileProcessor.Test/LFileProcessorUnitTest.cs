using NUnit.Framework;
using System;

namespace LFileProcessor.Test
{
    public class EFileProcessorTests
    {
        private FileProcessor _anyFileProcessor;

        [SetUp]
        public void Setup()
        {
            _anyFileProcessor = new FileProcessor();
        }

        [Test]
        public void FileDoesNotExist()
        {
            ArgumentException e = Assert.Throws<ArgumentException>(() => _anyFileProcessor.ProcessFile(AppDomain.CurrentDomain.BaseDirectory + @"con.txt"));
            Assert.That(e.Message, Is.EqualTo("The file doesn\'t exist..."));
        }

        [Test]
        public void FileiIsExist()
        {
            Assert.DoesNotThrow(() => _anyFileProcessor.ProcessFile(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\HtmlFile.html"));
        }

        [Test]
        public void IncorrectFormatFile()
        {
            ArgumentException e = Assert.Throws<ArgumentException>(() => _anyFileProcessor.ProcessFile(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\UdefineFile.undefine"));
            Assert.That(e.Message, Is.EqualTo("The file format is incorrect..."));
        }

        [Test]
        public void CorrectFormatFile()
        {
            Assert.DoesNotThrow(() => _anyFileProcessor.ProcessFile(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\HtmlFile.html"));
        }
    }
}