using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using text_file_statistc;

namespace TextFileStatisticsWebApi.Areas.Web_Service
{
    /// <summary>
    /// Summary description for WebServiceTextFileStatistcs
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class WebServiceTextFileStatistcs : System.Web.Services.WebService
    {
  
        [WebMethod]
        public string WrapLines(string sourceStr)
        {
            if (sourceStr == null)
            {
                throw new ArgumentNullException(nameof(sourceStr));
            }

            string result = TextFileStatistics.WrapLines(sourceStr);
            return result;
        }
      
        [WebMethod]
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