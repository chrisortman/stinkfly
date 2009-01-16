using System;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace StinkFly.Tests
{
	public class UrlParsing
	{
		public class When_parsing_url_of_two_fixed_string : Spec
		{
			private UrlPart[] parts;
			public override void EstablishContext() {
				UrlParser parser = new UrlParser();
				parts = parser.Parse("hello/index");
			}

			[Observation]
			public void should_have_two_parts()
			{
				parts.Length.ShouldEqual(2);
			}

			[Observation]
			public void first_part_should_be_fixed_string_part()
			{
				parts[0].ShouldEqual(new FixedStringUrlPart("hello"));
			}
		}
	}

	public class FixedStringUrlPart : UrlPart
	{
		private string _urlChunk;
		public FixedStringUrlPart(string urlChunk)
		{
			if(String.IsNullOrEmpty(urlChunk))
			{
				throw new ArgumentNullException("urlChunk", "urlChunk can not be null");
			}
			_urlChunk = urlChunk;
		}

		public bool Equals(FixedStringUrlPart obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj._urlChunk, _urlChunk);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (FixedStringUrlPart)) return false;
			return Equals((FixedStringUrlPart) obj);
		}

		public override int GetHashCode()
		{
			return _urlChunk.GetHashCode();
		}
	}

	public class UrlPart
	{
	}

	public class UrlParser
	{
		public UrlPart[] Parse(string url)
		{
			return new[]
			       	{
			       		new FixedStringUrlPart("hello"),
			       		new UrlPart()
			       	};
			
			
		}
	}
}