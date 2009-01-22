using System.Collections.Generic;
using System.Linq;

namespace StinkFly
{
	public class UrlParser
	{
		public IEnumerable<UrlPart> Parse(string url)
		{
			return SplitUrlIntoChunks(url).Where(x => x != "").Select(x => CreatePart(x));
		}

		private static string[] SplitUrlIntoChunks(string url)
		{
			return url.Split('/');
		}

		private static UrlPart CreatePart(string chunk)
		{
			if(chunk.StartsWith("{"))
			{
				return new VariableUrlPart(chunk);
			}
			else
			{
				return new FixedStringUrlPart(chunk);
			}
		}
	}
}