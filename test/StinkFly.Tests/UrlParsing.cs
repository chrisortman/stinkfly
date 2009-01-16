using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions.AssertExtensions;
using System.Linq;
namespace StinkFly.Tests
{
	public class UrlParsing
	{
		public class When_parsing_url_of_two_fixed_string : Spec
		{
			private UrlPart[] parts;
			public override void EstablishContext() {
				UrlParser parser = new UrlParser();
				parts = parser.Parse("hello/index").ToArray();
			}

			[Observation]
			public void should_have_two_parts()
			{
				parts.Length.ShouldEqual(2);
			}

			[Observation]
			public void first_part_should_be_fixed_string_part()
			{
				parts[0].ShouldBeType(typeof (FixedStringUrlPart));
			}

			[Observation]
			public void second_part_should_be_fixed_string_part()
			{
				parts[1].ShouldBeType(typeof (FixedStringUrlPart));
			}
		}

		public class When_parsing_url_of_with_one_fixed_string_and_one_variable : Spec
		{
			private UrlPart[] parts;

			public override void EstablishContext() {
				var parser = new UrlParser();
				parts = parser.Parse("hello/{name}").ToArray();
			}

			[Observation]
			public void should_have_two_parts()
			{
				parts.Length.ShouldEqual(2);
			}

			[Observation]
			public void second_part_should_be_variable_url_part()
			{
				parts[1].ShouldBeType(typeof (VariableUrlPart));
			}
		}
	}

	public class VariableUrlPart : UrlPart
	{
		private string _paramName;

		public VariableUrlPart(string chunk)
		{
			if(String.IsNullOrEmpty(chunk))
			{
				throw new Exception("Can't use empty chunk");
			}
			_paramName = chunk;
		}

		public override bool CanMatch(UrlPart other) {
		
			if(other is FixedStringUrlPart)
			{
				return true;
			} else if(other is VariableUrlPart)
			{
				return ((VariableUrlPart) other)._paramName.Equals(_paramName, StringComparison.InvariantCultureIgnoreCase);
			}
			else
			{
				return false;
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

		public override bool CanMatch(UrlPart other) {
			if(other is FixedStringUrlPart)
			{
				return ((FixedStringUrlPart) other)._urlChunk.Equals(_urlChunk, StringComparison.InvariantCultureIgnoreCase);
			}
			else
			{
				return false;
			}
		}
	}

	public class UrlPart
	{
		public virtual bool CanMatch(UrlPart other)
		{
			return true;
		}
	}

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