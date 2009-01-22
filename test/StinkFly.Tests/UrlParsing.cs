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
}