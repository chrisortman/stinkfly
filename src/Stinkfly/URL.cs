using System;
using System.Linq;

namespace StinkFly
{
	public class URL
	{
		private string _value;

		public URL(string value)
		{
			if(string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException("value", "Value can not be null or empty");
			}
			_value = value;
		}
		public override string ToString() {
			var parser = new UrlParser();
			var parts = parser.Parse(_value);
			var context = CallContext.Current;
			string url = "/";
			var last = parts.Last();
			foreach(var part in parts)
			{
				url += part.GenerateUrlFragment(context.Params);
				if (part != last)
				{
					url += "/";
				}
			}

			if(url.EndsWith("/"))
			{
				url = url.TrimEnd('/');
			}
			return url;
		}
	}

	public class WillBeDeferredLaterUrl
	{
		public override string ToString() {
		
			//TODO: An extension method on Part[] that returns string?
			return "";
		}
	}
}