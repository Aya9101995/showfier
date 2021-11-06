using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MWCore.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt, object HtmlAttributes)
        {
            TagBuilder oTag = new TagBuilder("img");
            oTag.Attributes.Add("src", src);
            oTag.Attributes.Add("alt", alt);
            if (HtmlAttributes != null)
            {
                oTag.MergeAttributes(new RouteValueDictionary(HtmlAttributes));
            }
            return new MvcHtmlString(oTag.ToString(TagRenderMode.SelfClosing));
        }
        public static string FingerPrint(string Path)
        {
            DateTime LastModificationDate = File.GetLastWriteTime(Path);
            int nIndex = Path.LastIndexOf('/');
            string Result = Path.Insert(nIndex, "/v-" + LastModificationDate.Ticks);
            return Result;
        }
    }
}