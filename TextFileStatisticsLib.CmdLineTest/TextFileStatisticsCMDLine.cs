
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_file_statistc;
using TextFileStatistcsWebApiClient;
using TextFileStatisticsLib;
using WebServiceCLient;

namespace TextFileStatisticsLib.CmdLineTest
{
    class TextFileStatisticsCMDLine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Web Service");
            string testInput =
                @"Line 1: qwerty uiop asdfg fdssdg dsgasd adra asdad qwerty uiop asdfg fdssdg dsgasd adra asdad ipoqw  qwerty uiop asdfg fdssdg dsgasd adra asdad ipoqw qwerty uiop asdfg fdssdg dsgasd adra asdad ipoqw  qwerty uiop asdfg fdssdg dsgasd adra asdad ipoqw 
Line 2: qwerty uiop asdfg fdssdg dsgasd adra asdad ipoqw  qwerty uiop asdfg fdssdg dsgasd adra asdad ipoqw  qwerty uiop asdfg fdssdg dsgasd adra asdad ipoqw ";
            string wrappedText = TextFileStatistics.WrapLines(testInput);
            Console.WriteLine(wrappedText);

            string html =
@"<html>
<head>
<body>
<title>proba</title>
<p>test if its working!</p>
<div>more test</div>
</body>
</head>
</html>";
            string textfromhtml = TextFileStatistics.GetTextFromHtml(html);
            Console.WriteLine(textfromhtml);

            Console.WriteLine("Testing Generated Api Client");

            DummyServiceClientCredentials dummyCredentials = new DummyServiceClientCredentials();
            TextFileStatisticsWebApi generatedClient = new TextFileStatisticsWebApi(dummyCredentials);

            Console.Write("Press a key to exit... ");
            Console.ReadKey();
        }
    }
}
