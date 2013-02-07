using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileMover
{
    class Program
    {
        static List<string> fullFileNames;
        static List<string> shortFileNames;
        static List<string> authorNames = new List<string>();
        //static ArrayList bookNames = new ArrayList();
        static List<ebook> bookNames = new List<ebook>();

        static string filePath = @"G:\Media\Kindle\";
        static void Main(string[] args)
        {
            //string pattern = Regex.Escape("\\");
            string filePattern = Regex.Escape(filePath);
            string ebookPattern = Regex.Escape(" - ");
            fullFileNames = Directory.GetFiles(filePath, "*.*")
                .ToList();
            foreach (var file in fullFileNames)
            {
                shortFileNames = Regex.Split(file, filePattern)
                    .ToList();
                foreach (string match in shortFileNames)
                {
                    Console.WriteLine("'{0}'", match); // do something
                    if (match.Length > 0) //filename
                    {
                        string[] ebook = Regex.Split(match, ebookPattern);
                        
                        authorNames.Add(ebook[0]);

                        ebook book = new ebook()
                            {
                                Author = ebook[0],
                                BookName= ebook[1]
                            };
                        bookNames.Add(book);
                    }
                }
            }
        }

    }
    public class ebook
    {
        public string BookName;
        public string Author;
        public DateTime PublishDate;
        public void New(String m_bkname, String m_author)
        {
            BookName = m_bkname;
            Author = m_author;
        }
        public void New(String m_bkname, String m_author, DateTime m_publishdate = default(DateTime))
        {
            BookName = m_bkname;
            Author = m_author;
            PublishDate = m_publishdate;
        }

    }
}
