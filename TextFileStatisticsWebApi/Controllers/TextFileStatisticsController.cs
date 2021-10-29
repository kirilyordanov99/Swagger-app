using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using text_file_statistc;

namespace TextFileStatisticsWebApi.Controllers
{
    public class TextFileStatisticsController : ApiController
    {
        [HttpPost]
        [Route("api/Methods/WrapLines/")]
        public string WrapLines(string sourceStr)
        {
            if (sourceStr == null)
            {
                throw new ArgumentNullException(nameof(sourceStr));
            }

            string result = TextFileStatistics.WrapLines(sourceStr);
            return result;
        }

        [HttpPost]
        [Route("api/Methods/GetTextFromHtml/")]
        public string GetTextFromHtml(string html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            string result = TextFileStatistics.GetTextFromHtml(html);
            return result;
        }
    }
}
