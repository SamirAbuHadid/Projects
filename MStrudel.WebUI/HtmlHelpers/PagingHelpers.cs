using MStrudel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MStrudel.WebUI.HtmlHelpers
{
	public static class PagingHelpers
	{
		public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
		{
			StringBuilder result = new StringBuilder();
			for(int i = 1; i <= pagingInfo.TotalPages; i++)
			{
				TagBuilder tag = new TagBuilder("a");
				tag.InnerHtml = i.ToString();
				tag.MergeAttribute("href", pageUrl(i));
				if(pagingInfo.CurrentPage == i)
				{
					tag.AddCssClass("selected");
					tag.AddCssClass("btn-primary");
				}
				tag.AddCssClass("btn btn-default");
				result.Append(tag.ToString());
			}
			return MvcHtmlString.Create(result.ToString());
		}
	}
}