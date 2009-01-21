using System;
using System.Collections.Generic;
using System.Linq;
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
			protected UrlMapper<string> _mapper;
			protected Dictionary<string,string> testUrls = new Dictionary<string, string>()
			{
				{"/hello/index","2fixed"},
				{"/hello/{name}","helloName"}
			};

			public override void EstablishContext() {
				_mapper = new UrlMapper<string>();
				
				foreach(var url in testUrls.Keys)
				{
					_mapper.AddUrl(url, testUrls[url]);
				}
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

		public class Try_not_to_be_order_dependent : When_mapping_urls_with_fixed_values_and_variables
		{
			public override void EstablishContext() 
			{
				_mapper = new UrlMapper<string>();
				foreach(var url in testUrls.Keys.Reverse())
				{
					_mapper.AddUrl(url, testUrls[url]);
				}
			}
		}
	}

	public class UrlMapper<RETURNS>
	{

		private UrlParser _parser;
		private UrlTree<UrlPart> _partTree;
		public UrlMapper()
		{
			_parser = new UrlParser();
			_partTree = new UrlTree<UrlPart>(new FixedStringUrlPart("/"));
		}


		public void AddUrl(string url, RETURNS mapsTo)
		{
			_partTree.MoveToRoot();

			var parts = _parser.Parse(url);
			
			var partsToDo = new Queue<UrlPart>(parts);
			while(partsToDo.Count > 0)
			{
				var currentPart = partsToDo.Dequeue();

				if(_partTree.MoveTo(currentPart))
				{
					continue;
				}
				else
				{
					_partTree.Add(currentPart);
					_partTree.MoveTo(currentPart);
				}
			}

			_partTree.AddExtensionData("mapsto", mapsTo);
		}

		public RETURNS Map(string url)
		{
			var parts = _parser.Parse(url);
			_partTree.MoveToRoot();
			foreach(var part in parts)
			{
				if(_partTree.MoveTo(part))
				{
					continue;
				}
				else if(_partTree.MoveToFirst(x => x.CanMatch(part)))
				{
					continue;
				}
			}

			return (RETURNS) _partTree.GetExtensionData("mapsto");
		}
	}
}