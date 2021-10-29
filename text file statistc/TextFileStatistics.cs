using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace text_file_statistc
{
    public class TextFileStatistics
    {
        public static readonly int MaxLineLength = 80;

        public static string WrapLines(string sourceStr)
        {
            if (sourceStr == null)
            {
                throw new ArgumentException(nameof(sourceStr));
            }
            StringBuilder sbOutput = new StringBuilder();
            using (StringReader rdr = new StringReader(sourceStr))
            {
                using (StringWriter wrtr = new StringWriter(sbOutput))
                {
                    string line;
                    bool firstLine = true;
                    while ((line = rdr.ReadLine()) != null)
                    {
                        if(firstLine == true)
                        {
                            firstLine = false;
                        }
                        else
                        {
                            wrtr.WriteLine();
                        }
                        if (line.Length <= MaxLineLength)
                        {
                            wrtr.WriteLine(line);
                        }
                        else
                        {
                            string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            int writtenLineSymbols = 0;
                            string wordsDelimiter = " ";
                            for(int i = 0; i < words.Length; i++)
                            {
                                string word = words[i];
                                if((writtenLineSymbols + wordsDelimiter.Length + word.Length) <= MaxLineLength)
                                {
                                    if(writtenLineSymbols > 0)
                                    {
                                        wrtr.Write(wordsDelimiter);
                                        writtenLineSymbols += wordsDelimiter.Length;
                                    }
                                    wrtr.Write(word);
                                    writtenLineSymbols += word.Length;
                                }
                                else
                                {
                                    wrtr.WriteLine();
                                    writtenLineSymbols = 0;
                                    wrtr.Write(word);
                                    writtenLineSymbols += word.Length;
                                }
                            }
                        }
                    }
                }
            }
            string result = sbOutput.ToString();
            return result;
        }

        //public static string WrapLines(Match regexMatch)
        //{
        //    throw new NotImplementedException();
        //}

        public static string GetTextFromHtml(string html)
        {
            if (html == null)
            {
                throw new ArgumentException(nameof(html));
            }
            string regExPattern = "<.*?>";
            string textOnly = Regex.Replace(html, regExPattern, TagWiper);
            return textOnly;
        }
        private static string TagWiper(Match regexMatch)
        {
            if (regexMatch == null)
            {
                throw new ArgumentException(nameof(regexMatch));
            }
            string replacement = string.Empty;
            if ((regexMatch.Success == true) && (regexMatch.Value != null) && (regexMatch.Value.StartsWith ("</") == true))
            {
                replacement = Environment.NewLine;
            }
            return replacement;
        }
    }
}
