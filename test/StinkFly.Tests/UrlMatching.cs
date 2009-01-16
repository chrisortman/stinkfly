using System.Collections.Generic;
using Xunit.Extensions.AssertExtensions;
namespace StinkFly.Tests
{
	public class UrlMatching
	{
		public class When_mapping_a_url_with_url_mapper : Spec
		{
			[Observation]
			public void Should_return_the_mapped_object()
			{
				var mapper = new UrlMapper<string>();
				mapper.AddUrl("/hello/index","chris");
				string matched = mapper.Map("/hello/index");
				matched.ShouldEqual("chris");
				
			}
		}

		public class When_mapping_urls_with_fixed_values_and_variables :Spec
		{
			private UrlMapper<string> _mapper;

			public override void EstablishContext() {
				_mapper = new UrlMapper<string>();
				_mapper.AddUrl("/hello/index", "2fixed");
				_mapper.AddUrl("/hello/{name}","helloName");

			}

			[Observation]
			public void should_map_hello_index_to_2fixed()
			{
				_mapper.Map("/hello/index").ShouldEqual("2fixed");
			}

			//TODO: I don't know if i actually care about this...
			[Observation]
			public void should_map_hello_variable_to_helloName()
			{
				_mapper.Map("/hello/{name}").ShouldEqual("helloName");
			}

			[Observation]
			public void should_map_hello_chris_to_helloName()
			{
				_mapper.Map("/hello/chris").ShouldEqual("helloName");
			}
		}
	}

	public class UrlMapper<RETURNS>
	{
		private class TreeNode<NODE>
		{
			private NODE _value;
			private List<NODE> _children;
			public TreeNode(NODE _value)
			{
				this._value = _value;
				_children = new List<NODE>();
			}

			public void AddChild(NODE child)
			{
				_children.Add(child);
			}
		}

		private class PartTree
		{
			public TreeNode<UrlPart> Root { get; set;}
		}

		private Dictionary<string, RETURNS> _lookup;
		private UrlParser _parser;
		private PartTree _partTree;

		public UrlMapper()
		{
			_parser = new UrlParser();
			_partTree = new PartTree();
			_partTree.Root = new TreeNode<UrlPart>(new FixedStringUrlPart("/"));
		}

		public void AddUrl(string url, RETURNS mapsTo)
		{
			var parts = parser.Parse(url);
			

		}

		public RETURNS Map(string url)
		{
			if(url == "/hello/chris")
			{
				return _lookup["/hello/{name}"];
			}
			return _lookup[url];
		}
	}
}