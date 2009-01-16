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
		private class TreeNode<NODE>
		{
			private NODE _value;

			private List<TreeNode<NODE>> _children;
			public TreeNode(NODE _value)
			{
				this._value = _value;
				_children = new List<TreeNode<NODE>>();
			}


			public TreeNode<NODE> AddChild(NODE child)
			{
				var newNode = new TreeNode<NODE>(child);
				_children.Add(newNode);
				return newNode;
			}

			public IEnumerable<TreeNode<NODE>> Children()
			{
				foreach(var c in _children)
				{
					yield return c;
				}
			}

			public NODE Value
			{
				get{ return _value;}
			}
		}

		private class PartTree
		{
			public TreeNode<UrlPart> Root { get; set;}
		}

		private Dictionary<TreeNode<UrlPart>, RETURNS> _lookup;
		private UrlParser _parser;
		private PartTree _partTree;

		public UrlMapper()
		{
			_parser = new UrlParser();
			_partTree = new PartTree();
			_lookup = new Dictionary<TreeNode<UrlPart>, RETURNS>();
			_partTree.Root = new TreeNode<UrlPart>(new FixedStringUrlPart("/"));
		}

		public void AddUrl(string url, RETURNS mapsTo)
		{
			var parts = _parser.Parse(url);
			var currentNode = _partTree.Root;
			var partsToDo = new Queue<UrlPart>(parts);
			while(partsToDo.Count > 0)
			{
				var currentPart = partsToDo.Dequeue();
				bool partIsAlreadyInTree = false;
				foreach(var node in currentNode.Children())
				{
					if(node.Value.CanMatch(currentPart))
					{
						partIsAlreadyInTree = true;
						currentNode = node;
						break;
					}
				}

				if(!partIsAlreadyInTree)
				{
					currentNode = currentNode.AddChild(currentPart);
				}
			}

			_lookup.Add(currentNode,mapsTo);

		}

		public RETURNS Map(string url)
		{
			var parts = _parser.Parse(url);
			var partsToDo = new Queue<UrlPart>(parts);
			var currentNode = _partTree.Root;
			while(partsToDo.Count > 0)
			{
				var currentPart = partsToDo.Dequeue();
				bool found = false;
				foreach (var child in currentNode.Children())
				{
					if(child.Value.CanMatch(currentPart))
					{
						currentNode = child;
						found = true;
						break;
					}
				}

				if(!found)
				{
					throw new Exception("Couldn't find a match");
				}
			}

			return _lookup[currentNode];
		}
	}
}