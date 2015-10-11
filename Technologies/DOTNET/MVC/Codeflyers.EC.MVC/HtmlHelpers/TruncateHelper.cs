using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Codeflyers.EC.MVC.Models;

namespace Codeflyers.EC.MVC.HtmlHelpers
{
    public static class TruncateHelper
    {
        public static string Truncate(this HtmlHelper html, string orginalString, int length)
        {
            return orginalString.Substring(0, length)+"...";
        }
    }
}